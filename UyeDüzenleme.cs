using iText.IO.Font.Constants;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Vml;

namespace utkfitnes
{

    public partial class UyeDüzenleme : Form
    {
        private string baglantiadres = "Server=UTKU\\SQLEXPRESS;Database=utkfitness;Trusted_Connection=True;";
        public UyeDüzenleme()
        {
            InitializeComponent();
        }




        private void UyeDüzenleme_Load(object sender, EventArgs e)
        {
             // ListView'ı doldur
            UyeListesiYukle();
            GirisCıkısTablosuVerileri();
            VerileriComboBoxaYukle();
            uyelistesinieklepform();

        }

        private void lvUyeListesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Eğer bir satır seçiliyse
            if (lvUyeListesi.SelectedItems.Count > 0)
            {
                // Seçilen satırı al
                ListViewItem selectedItem = lvUyeListesi.SelectedItems[0];

                // İstediğiniz sütunun değerini al (örneğin, "Adı" sütunu)
                string adı = selectedItem.SubItems[1].Text;

                // TextBox'a yazdır
                txtuyeadı.Text = adı;
            }
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            string uyeAdi = txtuyeadı.Text;
            string egzersiz = cmboxfitness.SelectedItem?.ToString(); // Seçilen egzersiz programı

            // Giriş tarihi
            DateTime girisTarihi = DateTime.Now;

            if (string.IsNullOrEmpty(uyeAdi) || string.IsNullOrEmpty(egzersiz))
            {
                MessageBox.Show("Lütfen tüm bilgileri doldurun!");
                return;
            }

            using (SqlConnection connection = new SqlConnection(baglantiadres))
            {
                connection.Open();

                // Uyeler tablosundan ÜyeID'yi al
                string idcagır = "SELECT uyeID FROM uyeler WHERE ad=@ad";
                SqlCommand komut = new SqlCommand(idcagır, connection);
                komut.Parameters.AddWithValue("@ad", uyeAdi);

                object uyeobj = komut.ExecuteScalar();

                if (uyeobj == null)
                {
                    MessageBox.Show("Üye bulunamadı!");
                    return;
                }

                int uyeID = Convert.ToInt32(uyeobj);

                // Çıkışı olmayan aynı egzersiz programı için bir giriş kontrolü yap
                string kontrolQuery = "SELECT COUNT(*) FROM UyeGirisCikis " +
                                      "WHERE UyeID = @UyeID AND CikisTarihi IS NULL AND EgzersizProgrami = @EgzersizProgrami";
                SqlCommand kontrolCommand = new SqlCommand(kontrolQuery, connection);
                kontrolCommand.Parameters.AddWithValue("@UyeID", uyeID);
                kontrolCommand.Parameters.AddWithValue("@EgzersizProgrami", egzersiz);

                int mevcutKayit = Convert.ToInt32(kontrolCommand.ExecuteScalar());

                if (mevcutKayit > 0)
                {
                    MessageBox.Show("Bu üye için aynı egzersiz programına ait çıkışı yapılmamış bir giriş zaten mevcut!");
                    return;
                }

                // Giriş kaydını ekle
                string insertQuery = "INSERT INTO UyeGirisCikis (UyeID, GirisTarihi, CikisTarihi, EgzersizProgrami) " +
                                     "VALUES (@UyeID, @GirisTarihi, NULL, @EgzersizProgrami)";
                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@UyeID", uyeID);
                insertCommand.Parameters.AddWithValue("@GirisTarihi", girisTarihi);
                insertCommand.Parameters.AddWithValue("@EgzersizProgrami", egzersiz);

                insertCommand.ExecuteNonQuery();

                MessageBox.Show("Giriş kaydı başarıyla eklendi!");

                // ListView'i güncelle
                GirisCıkısTablosuVerileri();
                txtuyeadı.Text = "";
                cmboxfitness.Text = "";
            }
        }

        private void UyeListesiYukle()
        {
            lvUyeListesi.Items.Clear();

            string sorgu = "SELECT uyeID, ad,soyad FROM uyeler"; // Üyeleri getir
            using (SqlConnection baglanti = new SqlConnection(baglantiadres))
            {
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();

                while (okuyucu.Read())
                {
                    ListViewItem item = new ListViewItem(okuyucu["uyeID"].ToString());
                    item.SubItems.Add(okuyucu["ad"].ToString());
                    item.SubItems.Add(okuyucu["soyad"].ToString());
                    lvUyeListesi.Items.Add(item);
                }

                baglanti.Close();
            }
        }
        private void GirisCıkısTablosuVerileri()
        {


            string sorgu = @"
                            SELECT UyeGirisCikis.uyeID, uyeler.ad, UyeGirisCikis.giristarihi, 
                            UyeGirisCikis.cikistarihi, UyeGirisCikis.EgzersizProgrami
                            FROM UyeGirisCikis INNER JOIN uyeler ON UyeGirisCikis.uyeID = uyeler.uyeID"; // Hata burada düzeltildi

            lvGirisCikis.Items.Clear(); // Eski verileri temizle

            using (SqlConnection baglantı = new SqlConnection(baglantiadres))
            {

                SqlCommand komut = new SqlCommand(sorgu, baglantı);
                baglantı.Open();
                SqlDataReader reader = komut.ExecuteReader();

                while (reader.Read())
                {
                    // Her satırdaki verileri ListView'e ekliyoruz
                    ListViewItem item = new ListViewItem(reader["uyeID"].ToString()); // İlk sütun: ÜyeID
                    item.SubItems.Add(reader["ad"].ToString());                      // İkinci sütun: Adı
                    item.SubItems.Add(Convert.ToDateTime(reader["giristarihi"]).ToString("dd/MM/yyyy HH:mm")); // Üçüncü sütun: Giriş Tarihi
                    item.SubItems.Add(reader["cikistarihi"] == DBNull.Value ? "—" : Convert.ToDateTime(reader["cikistarihi"]).ToString("dd/MM/yyyy HH:mm")); // Dördüncü sütun: Çıkış Tarihi
                    item.SubItems.Add(reader["EgzersizProgrami"].ToString()); // Beşinci sütun: Egzersiz Programı
                    lvGirisCikis.Items.Add(item); // Satırı ListView'e ekle
                }
                baglantı.Close();
            }


        }

        private void btnCikisYap_Click(object sender, EventArgs e)
        {

            int uyeID;

            // ListView'den seçilen ÜyeID'yi kontrol et
            if (lvGirisCikis.SelectedItems.Count > 0)
            {
                uyeID = Convert.ToInt32(lvGirisCikis.SelectedItems[0].Text); // İlk sütundaki ÜyeID
            }
            else
            {
                MessageBox.Show("Lütfen çıkış yapacak bir üye seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Çıkış tarihi için şimdiki zamanı al
            DateTime cikisTarihi = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(baglantiadres))
            {
                connection.Open();
                string updateQuery = "UPDATE UyeGirisCikis " +
                                     "SET cikistarihi = @cikistarihi " +
                                     "WHERE uyeID = @uyeID AND cikistarihi IS NULL";

                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@cikistarihi", cikisTarihi);
                command.Parameters.AddWithValue("@uyeID", uyeID);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Çıkış kaydı başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GirisCıkısTablosuVerileri(); // ListView'i yenile
                }
                else
                {
                    MessageBox.Show("Çıkış kaydı eklenemedi! Daha önce çıkış yapılmış olabilir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void lvGirisCikis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvGirisCikis.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvGirisCikis.SelectedItems[0];

                // Üye Adı ve Egzersiz Programı bilgilerini al
                txtuyeadı.Text = selectedItem.SubItems[1].Text; // İkinci sütun: Adı
                cmboxfitness.Text = selectedItem.SubItems[4].Text; // Beşinci sütun: Egzersiz Programı
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtuyeadı.Text = "";
            cmboxfitness.Text = "";
        }
        //-----------TABPAGE2-----------------------------------------------------------------------------------
        private void VerileriComboBoxaYukle()
        {
            string query = "SELECT ad FROM uyeler";
            using (SqlConnection baglanti = new SqlConnection(baglantiadres))
            {
                try
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand(query, baglanti);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // ComboBox'ı temizle
                    cmboxuyead.Items.Clear();

                    // Verileri ComboBox'a ekle
                    while (reader.Read())
                    {
                        cmboxuyead.Items.Add(reader["ad"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
            
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {

            if (cmboxuyead.SelectedItem != null)
            {
                string secilenAd = cmboxuyead.SelectedItem.ToString();
                string query = @"SELECT 
                            UyeGirisCikis.uyeID, 
                            uyeler.ad, 
                            uyeler.soyad, 
                            UyeGirisCikis.giristarihi, 
                            UyeGirisCikis.cikistarihi, 
                            UyeGirisCikis.EgzersizProgrami 
                         FROM UyeGirisCikis 
                         INNER JOIN uyeler ON UyeGirisCikis.uyeID = uyeler.uyeID 
                         WHERE uyeler.ad = @ad";

                using (SqlConnection baglanti = new SqlConnection(baglantiadres))
                {
                    try
                    {
                        baglanti.Open();
                        SqlCommand cmd = new SqlCommand(query, baglanti);
                        cmd.Parameters.AddWithValue("@ad", secilenAd);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        lvp2.Items.Clear(); // Önce ListView'i temizliyoruz

                        // Gelen verileri ListView'e ekle
                        foreach (DataRow row in dt.Rows)
                        {
                            ListViewItem item = new ListViewItem(row["uyeID"].ToString());
                            item.SubItems.Add(row["ad"].ToString());
                            item.SubItems.Add(row["soyad"].ToString());
                            item.SubItems.Add(row["giristarihi"].ToString());
                            item.SubItems.Add(row["cikistarihi"].ToString());
                            item.SubItems.Add(row["EgzersizProgrami"].ToString());
                            lvp2.Items.Add(item);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir ad seçin.");
            }


        }

        private void btnPDF_Click(object sender, EventArgs e)
        {

            try
            {
                // ListView'in içeriği boş mu kontrol et
                if (lvp2.Items.Count == 0)
                {
                    MessageBox.Show("Liste'de veri bulunmamaktadır. Lütfen verileri ekleyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;  // Eğer boşsa, işlemi durdur
                }
                // PDF kaydedileceği konumu seçmek için bir SaveFileDialog
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF File|*.pdf";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // PDF oluşturma
                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        using (PdfWriter writer = new PdfWriter(fs))
                        {
                            using (iText.Kernel.Pdf.PdfDocument pdf = new iText.Kernel.Pdf.PdfDocument(writer))
                            {
                                Document document = new Document(pdf);

                                // ListView başlıkları ve içeriklerini PDF'ye eklemek
                                Table table = new Table(6);  // Örnek: 2 sütunlu bir tablo

                                // Başlıklar
                                table.AddCell("Üye ID");
                                table.AddCell("Ad");
                                table.AddCell("Soyad");
                                table.AddCell("Giriş Tarihi");
                                table.AddCell("Çıkış Tarihi");
                                table.AddCell("Egzersiz Programı");


                                // ListView verileri
                                foreach (ListViewItem item in lvp2.Items)
                                {
                                    table.AddCell(item.SubItems[0].Text);  // 1. sütun
                                    table.AddCell(item.SubItems[1].Text);  // 2. sütun
                                    table.AddCell(item.SubItems[2].Text);
                                    table.AddCell(item.SubItems[3].Text);
                                    table.AddCell(item.SubItems[4].Text);
                                    table.AddCell(item.SubItems[5].Text);

                                }

                                // Tabloyu PDF'ye ekleyin
                                document.Add(table);
                            }
                        }
                    }

                    MessageBox.Show("PDF başarıyla kaydedildi.");
                }
            }
            catch (Exception ex)
            {
                // Hata mesajını gösteriyoruz
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // ListView'in içeriği boş mu kontrol et
                if (lvp2.Items.Count == 0)
                {
                    MessageBox.Show("ListView'de veri bulunmamaktadır. Lütfen verileri ekleyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;  // Eğer boşsa, işlemi durdur
                }

                // Kullanıcının dosya adı ve yolunu seçmesi için SaveFileDialog kullan
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
                    saveFileDialog.Title = "Excel Dosyası Kaydet";
                    saveFileDialog.FileName = "output.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Excel dosyasını oluşturuyoruz
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Veriler");

                            // Sütun başlıklarını ekliyoruz
                            worksheet.Cell(1, 1).Value = "Üye ID";
                            worksheet.Cell(1, 2).Value = "Ad";
                            worksheet.Cell(1, 3).Value = "Soyad";
                            worksheet.Cell(1, 4).Value = "Giriş Tarihi";
                            worksheet.Cell(1, 5).Value = "Çıkış Tarihi";
                            worksheet.Cell(1, 6).Value = "Egzersiz Programı";

                            // ListView'deki her bir öğeyi ekliyoruz
                            int row = 2; // Veriler 2. satırdan başlıyor
                            foreach (ListViewItem item in lvp2.Items)
                            {
                                worksheet.Cell(row, 1).Value = item.SubItems[0].Text; // 1. sütun
                                worksheet.Cell(row, 2).Value = item.SubItems[1].Text; // 2. sütun
                                worksheet.Cell(row, 3).Value = item.SubItems[2].Text; // 3. sütun
                                worksheet.Cell(row, 4).Value = item.SubItems[3].Text; // 4. sütun
                                worksheet.Cell(row, 5).Value = item.SubItems[4].Text; // 5. sütun
                                worksheet.Cell(row, 6).Value = item.SubItems[5].Text; // 6. sütun
                                row++;
                            }

                            // Kullanıcının seçtiği yola kaydet
                            workbook.SaveAs(saveFileDialog.FileName);

                            // Başarılı mesajı
                            MessageBox.Show("Excel başarıyla oluşturuldu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata mesajını gösteriyoruz
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        //-----------TABPAGE3-----------------------------------------------------------------------------------
        
        private void uyelistesinieklepform()
        {
            // SQL sorgusu
            string sorgu = "SELECT uyeID, ad, soyad, yas, telno , UyelikSuresi FROM uyeler";

            // Veritabanı bağlantısı
            using (SqlConnection baglanti = new SqlConnection(baglantiadres))
            {
                try
                {
                    baglanti.Open();

                    // SQL komutunu oluştur
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);

                    // Verileri oku
                    SqlDataReader okuyucu = komut.ExecuteReader();

                    // ListView'i temizle
                    lvtb3.Items.Clear();

                    // Verileri ListView'e ekle
                    while (okuyucu.Read())
                    {
                        ListViewItem item = new ListViewItem(okuyucu["uyeID"].ToString());
                        item.SubItems.Add(okuyucu["ad"].ToString());
                        item.SubItems.Add(okuyucu["soyad"].ToString());
                        item.SubItems.Add(okuyucu["yas"].ToString());
                        item.SubItems.Add(okuyucu["telno"].ToString());
                        item.SubItems.Add(okuyucu["UyelikSuresi"].ToString());

                        lvtb3.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri yüklenirken hata oluştu: " + ex.Message);
                }
            }
        }
        private void lvtb3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Eğer bir satır seçilmişse
            if (lvtb3.SelectedItems.Count > 0)
            {
                ListViewItem seciliSatir = lvtb3.SelectedItems[0];

                // Seçilen satırdaki bilgileri al ve TextBox'lara aktar
                txtadtb3.Text = seciliSatir.SubItems[1].Text;   // Ad
                txtsadtb2.Text = seciliSatir.SubItems[2].Text; // Soyad
                txtyastb3.Text = seciliSatir.SubItems[3].Text;   // Yaş
                txttelnotb3.Text = seciliSatir.SubItems[4].Text; // Telefon Numarası
                cmboxustb3.Text = seciliSatir.SubItems[5].Text; //aylık üyelik sayısı
            }
            else
            {
                // Eğer hiçbir satır seçilmemişse TextBox'ları temizle
                txtadtb3.Text = "";
                txtsadtb2.Text = "";
                txtyastb3.Text = "";
                txttelnotb3.Text = "";
                cmboxustb3.Text = "";
            }
        }
        private void btnekletb2_Click(object sender, EventArgs e)
        {
            string ad = txtadtb3.Text;
            string soyad = txtsadtb2.Text;
            int yas = Convert.ToInt32(txtyastb3.Text);
            string telno = txttelnotb3.Text;
            int aylıkuyekayıt = Convert.ToInt32(cmboxustb3.Text);
            // Veritabanına ekleme işlemi
            string sorgu = "INSERT INTO uyeler (ad, soyad, yas, telno,UyelikSuresi) VALUES (@ad, @soyad, @yas, @telno, @uyelikSuresi)";

            using (SqlConnection baglanti = new SqlConnection(baglantiadres))
            {
                try
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@ad", ad);
                    komut.Parameters.AddWithValue("@soyad", soyad);
                    komut.Parameters.AddWithValue("@yas", yas);
                    komut.Parameters.AddWithValue("@telno", telno);
                    komut.Parameters.AddWithValue("@uyelikSuresi", aylıkuyekayıt);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Yeni üye başarıyla eklendi.");

                    uyelistesinieklepform();  // Listeyi yenile
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ekleme işlemi sırasında hata: " + ex.Message);
                }
            }
        
        }

        private void btngnctb3_Click(object sender, EventArgs e)
        {
            // Seçili üye bilgilerini almak için ListView'den seçilen satırdan değerler alınabilir.
            if (lvtb3.SelectedItems.Count > 0)
            {
                string uyeID = lvtb3.SelectedItems[0].SubItems[0].Text;
                string ad = txtadtb3.Text;
                string soyad = txtsadtb2.Text;
                int yas = Convert.ToInt32(txtyastb3.Text);
                string telno = txttelnotb3.Text;
                int aylıkuyekayıt = Convert.ToInt32(cmboxustb3.Text);

                // Güncelleme sorgusu
                string sorgu = "UPDATE uyeler SET ad = @ad, soyad = @soyad, yas = @yas, telno = @telno,UyelikSuresi=@uyelikSuresi  WHERE uyeID = @uyeID";

                using (SqlConnection baglanti = new SqlConnection(baglantiadres))
                {
                    try
                    {
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand(sorgu, baglanti);
                        komut.Parameters.AddWithValue("@ad", ad);
                        komut.Parameters.AddWithValue("@soyad", soyad);
                        komut.Parameters.AddWithValue("@yas", yas);
                        komut.Parameters.AddWithValue("@telno", telno);
                        komut.Parameters.AddWithValue("@uyeID", uyeID);
                        komut.Parameters.AddWithValue("@uyelikSuresi", aylıkuyekayıt);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Üye bilgileri başarıyla güncellendi.");
                        uyelistesinieklepform();  // Listeyi yenile
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Güncelleme sırasında hata: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek için bir üye seçin.");
            }
        }

        private void btnsiltb3_Click(object sender, EventArgs e)
        {
            
                string uyeID = lvtb3.SelectedItems[0].SubItems[0].Text;

                // Silme sorgusu
                string sorgu = "DELETE FROM uyeler WHERE uyeID = @uyeID";

                using (SqlConnection baglanti = new SqlConnection(baglantiadres))
                {
                    try
                    {
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand(sorgu, baglanti);
                        komut.Parameters.AddWithValue("@uyeID", uyeID);

                        komut.ExecuteNonQuery();
                        MessageBox.Show("Üye başarıyla silindi.");
                        uyelistesinieklepform();  // Listeyi yenile
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Silme sırasında hata: " + ex.Message);
                    }
                }
            
        }

        private void btnyenile_Click(object sender, EventArgs e)
        {
            uyelistesinieklepform();
            UyeListesiYukle();
            VerileriComboBoxaYukle();
        }

       
    }

}



