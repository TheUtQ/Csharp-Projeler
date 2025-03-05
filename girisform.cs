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
    public partial class GirisFormu : Form
    {
        public GirisFormu()
        {
            InitializeComponent();
        }
        private string baglantiadres = "Server=UTKU\\SQLEXPRESS;Database=utkfitness;Trusted_Connection=True;";
        public string rol;
        private void btnGiris_Click(object sender, EventArgs e)
        {
            // Kullanıcı adı ve şifreyi al
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text;

            // Boş alan kontrolü
            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(baglantiadres))//veritabanı çalıştırılıyor.
                {
                    connection.Open();

                    // Kullanıcıyı kontrol et
                    string secici = "SELECT Rol FROM Kullanici WHERE KullaniciAdi = @kullaniciAdi AND Sifre = @sifre";
                    using (SqlCommand command = new SqlCommand(secici, connection))
                    {
                        command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                        command.Parameters.AddWithValue("@sifre", sifre);

                        object result = command.ExecuteScalar();//sorguda çalışan rol bilgisini almaya yarar.

                        if (result != null)
                            rol=result.ToString();
                        {
                            switch (rol)//rollere göre hangi panele giriş yapılacağının sorgusu yapılıyor.
                            {
                                case "Yönetici"://rol==Yönetici olduğunda
                                    
                                    AdminPaneli adminPaneli = new AdminPaneli();
                                    adminPaneli.FormClosed += new FormClosedEventHandler(FormClosedHandler);
                                    adminPaneli.Show();
                                    this.Hide();
                                     // Mevcut formu gizle
                                    break;

                                case "Personel"://rol==Personel olduğunda
                                    UyeDüzenleme uyeDuzenleme = new UyeDüzenleme();
                                    uyeDuzenleme.FormClosed += new FormClosedEventHandler(FormClosedHandler);
                                    uyeDuzenleme.Show();
                                    this.Hide(); // Mevcut formu gizle
                                    break;
                                default:
                                    MessageBox.Show("Geçersiz rol tespit edildi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormClosedHandler(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Tüm uygulamayı kapatır
        }

        private void btnpass_Click(object sender, EventArgs e)
        {
            if (txtSifre.PasswordChar == '*')
            {
                txtSifre.PasswordChar = '\0'; // Şifreyi göster
                     
            }
            else
            {
                txtSifre.PasswordChar = '*'; // Şifreyi gizle   
            }
        }
    }
}
