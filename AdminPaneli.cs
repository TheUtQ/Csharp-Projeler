using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace utkfitnes
{
    public partial class AdminPaneli : Form
    {
        private string baglantiadres = "Server=UTKU\\SQLEXPRESS;Database=utkfitness;Trusted_Connection=True;";
        public AdminPaneli()
        {
            InitializeComponent();
            UyeListesiniYukle();
        }

        private void KullaniciListele()
        {
            listView1.Items.Clear();

            // Veritabanından verileri çek
            string sorgu = "SELECT * FROM Kullanici";

            using (SqlConnection baglanti = new SqlConnection(baglantiadres))
            {
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                baglanti.Open();

                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    ListViewItem item = new ListViewItem(okuyucu["KullaniciAdi"].ToString());
                    item.SubItems.Add(okuyucu["Sifre"].ToString());
                    item.SubItems.Add(okuyucu["Rol"].ToString());
                    listView1.Items.Add(item);//başlıkları ekle.
                }
                baglanti.Close();
            }
        }

        private void AdminPaneli_Load(object sender, EventArgs e)
        {

            // ListView'ı doldur
            KullaniciListele();


        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Seçilen satırdaki kullanıcı adı, şifre ve rol bilgilerini al
                string kullaniciAdi = listView1.SelectedItems[0].SubItems[0].Text;
                string sifre = listView1.SelectedItems[0].SubItems[1].Text;
                string rol = listView1.SelectedItems[0].SubItems[2].Text;

                // TextBox'lara verileri yerleştir
                txtAd.Text = kullaniciAdi;
                txtSifre.Text = sifre;
                cmboxRol.SelectedItem = rol;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string kad = txtAd.Text;
            string sifre = txtSifre.Text;
            string rol = cmboxRol.SelectedItem.ToString();

            // Veritabanına ekle
            string sorgu = "INSERT INTO Kullanici(KullaniciAdi,Sifre,Rol) VALUES (@KullaniciAdi,@Sifre,@Rol)";
            using (SqlConnection baglanti = new SqlConnection(baglantiadres))
            {
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@KullaniciAdi", kad);
                komut.Parameters.AddWithValue("@Sifre", sifre);
                komut.Parameters.AddWithValue("@Rol", rol);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
            }

            // Veritabanını güncelle ve ListView'ı yeniden yükle
            KullaniciListele();
        }


        private void btngnc_Click(object sender, EventArgs e)
        {
            // Kullanıcı adı, şifre ve rol bilgilerini al
            string kullaniciAdi = txtAd.Text;  // Kullanıcı adı
            string sifre = txtSifre.Text;  // Yeni şifre
            string rol = cmboxRol.SelectedItem.ToString();  // Yeni rol

            // Kullanıcı adı, şifre ve rol boş olmamalı
            if (string.IsNullOrEmpty(kullaniciAdi))
            {
                MessageBox.Show("Kullanıcı adı boş olamaz.");
                return;
            }

            if (string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Şifre boş olamaz.");
                return;
            }

            if (string.IsNullOrEmpty(rol))
            {
                MessageBox.Show("Rol boş olamaz.");
                return;
            }

            // Veritabanındaki kullanıcıyı güncellemek için SQL sorgusu
            string sorgu = "UPDATE Kullanici SET Sifre = @Sifre, Rol = @Rol WHERE KullaniciAdi = @KullaniciAdi";



            using (SqlConnection baglanti = new SqlConnection(baglantiadres))
            {
                try
                {
                    // Bağlantıyı aç
                    baglanti.Open();

                    // Sorgu komutunu oluştur
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);

                    // Parametreleri ekle
                    komut.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                    komut.Parameters.AddWithValue("@Sifre", sifre);
                    komut.Parameters.AddWithValue("@Rol", rol);

                    // Sorguyu çalıştır
                    int sonuc = komut.ExecuteNonQuery();

                    // Eğer 0'dan büyük bir değer dönerse, güncelleme başarılıdır
                    if (sonuc > 0)
                    {
                        MessageBox.Show("Kullanıcı başarıyla güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı bulunamadı veya değişiklik yapılmadı.");
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Veritabanı hatası: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
                finally
                {
                    // Bağlantıyı kapat
                    baglanti.Close();
                }
            }

            // ListView'ı yeniden yükle
            KullaniciListele();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            // Kullanıcı adı bilgisi al
            string kullaniciAdi = txtAd.Text;  // Kullanıcı adı

            // Kullanıcı adı boş olmamalı
            if (string.IsNullOrEmpty(kullaniciAdi))
            {
                MessageBox.Show("Kullanıcı adı boş olamaz.");
                return;
            }

            // Silme sorgusu (Veritabanından sil)
            string sorgu = "DELETE FROM Kullanici WHERE KullaniciAdi = @KullaniciAdi";



            using (SqlConnection baglanti = new SqlConnection(baglantiadres))
            {
                try
                {
                    // Bağlantıyı aç
                    baglanti.Open();

                    // Sorgu komutunu oluştur
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);

                    // Parametreyi ekle
                    komut.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);

                    // Sorguyu çalıştır
                    int sonuc = komut.ExecuteNonQuery();

                    // Eğer 0'dan büyük bir değer dönerse, silme işlemi başarılıdır
                    if (sonuc > 0)
                    {
                        MessageBox.Show("Kullanıcı başarıyla silindi.");
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı bulunamadı veya silme işlemi başarısız oldu.");
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Veritabanı hatası: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
                finally
                {
                    // Bağlantıyı kapat
                    baglanti.Close();
                }
            }

            // ListView'ı yeniden yükle
            KullaniciListele();
        }
        private void btnformreset_Click(object sender, EventArgs e)
        {
            txtAd.Text = string.Empty;
            txtSifre.Text = string.Empty;
            cmboxRol.Text = string.Empty;
        }
        //üye Listesi Sekmesi----------------------------------------------------------------------------------------------------------

        // ListView'e üye bilgilerini yükle
        private void UyeListesiniYukle()
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
                    lvuyelertable.Items.Clear();

                    // Verileri ListView'e ekle
                    while (okuyucu.Read())
                    {
                        ListViewItem item = new ListViewItem(okuyucu["uyeID"].ToString());
                        item.SubItems.Add(okuyucu["ad"].ToString());
                        item.SubItems.Add(okuyucu["soyad"].ToString());
                        item.SubItems.Add(okuyucu["yas"].ToString());
                        item.SubItems.Add(okuyucu["telno"].ToString());
                        item.SubItems.Add(okuyucu["UyelikSuresi"].ToString());

                        lvuyelertable.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri yüklenirken hata oluştu: " + ex.Message);
                }
            }
        }

        private void ekleButton_Click(object sender, EventArgs e)
        {
            string ad = adTextBox.Text;
            string soyad = soyadTextBox.Text;
            int yas = Convert.ToInt32(yasTextBox.Text);
            string telno = telnoTextBox.Text;
            int aylıkuyekayıt =Convert.ToInt32(cmboxaylık.Text);

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

                    UyeListesiniYukle();  // Listeyi yenile
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ekleme işlemi sırasında hata: " + ex.Message);
                }
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)//formu silme 
        {
            adTextBox.Text= string.Empty;
            soyadTextBox.Text= string.Empty;
            telnoTextBox.Text= string.Empty;
            yasTextBox.Text= string.Empty;
            cmboxaylık.Text= string.Empty;

        }

        private void guncelleButton_Click(object sender, EventArgs e)
        {
            // Seçili üye bilgilerini almak için ListView'den seçilen satırdan değerler alınabilir.
            if (lvuyelertable.SelectedItems.Count > 0)
            {
                string uyeID = lvuyelertable.SelectedItems[0].SubItems[0].Text;
                string ad = adTextBox.Text;
                string soyad = soyadTextBox.Text;
                int yas = Convert.ToInt32(yasTextBox.Text);
                string telno = telnoTextBox.Text;
                int aylıkuyekayıt = Convert.ToInt32(cmboxaylık.Text);

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
                        UyeListesiniYukle();  // Listeyi yenile
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

        private void silButton_Click(object sender, EventArgs e)
        {
            // Seçili üye bilgilerini almak için ListView'den seçilen satırdan değerler alınabilir.
            if (lvuyelertable.SelectedItems.Count > 0)
            {
                string uyeID = lvuyelertable.SelectedItems[0].SubItems[0].Text;

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
                        UyeListesiniYukle();  // Listeyi yenile
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Silme sırasında hata: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir üye seçin.");
            }
        }

        private void lvuyelertable_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Eğer bir satır seçilmişse
            if (lvuyelertable.SelectedItems.Count > 0)
            {
                ListViewItem seciliSatir = lvuyelertable.SelectedItems[0];

                // Seçilen satırdaki bilgileri al ve TextBox'lara aktar
                adTextBox.Text = seciliSatir.SubItems[1].Text;   // Ad
                soyadTextBox.Text = seciliSatir.SubItems[2].Text; // Soyad
                yasTextBox.Text = seciliSatir.SubItems[3].Text;   // Yaş
                telnoTextBox.Text = seciliSatir.SubItems[4].Text; // Telefon Numarası
                cmboxaylık.Text = seciliSatir.SubItems[5].Text; //aylık üyelik sayısı
            }
            else
            {
                // Eğer hiçbir satır seçilmemişse TextBox'ları temizle
                adTextBox.Text = "";
                soyadTextBox.Text = "";
                yasTextBox.Text = "";
                telnoTextBox.Text = "";
                cmboxaylık.Text ="";
            }
        }

    }
}
