namespace utkfitnes
{
    partial class GirisFormu
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisFormu));
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.btnGiris = new System.Windows.Forms.Button();
            this.btnpass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtKullaniciAdi.Location = new System.Drawing.Point(62, 181);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(164, 22);
            this.txtKullaniciAdi.TabIndex = 0;
            // 
            // txtSifre
            // 
            this.txtSifre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtSifre.Location = new System.Drawing.Point(62, 241);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(164, 22);
            this.txtSifre.TabIndex = 1;
            // 
            // btnGiris
            // 
            this.btnGiris.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnGiris.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGiris.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGiris.Location = new System.Drawing.Point(95, 290);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(106, 30);
            this.btnGiris.TabIndex = 2;
            this.btnGiris.Text = "Giriş Yap";
            this.btnGiris.UseVisualStyleBackColor = true;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // btnpass
            // 
            this.btnpass.Image = ((System.Drawing.Image)(resources.GetObject("btnpass.Image")));
            this.btnpass.Location = new System.Drawing.Point(252, 227);
            this.btnpass.Name = "btnpass";
            this.btnpass.Size = new System.Drawing.Size(35, 36);
            this.btnpass.TabIndex = 3;
            this.btnpass.UseVisualStyleBackColor = true;
            this.btnpass.Click += new System.EventHandler(this.btnpass_Click);
            // 
            // GirisFormu
            // 
            this.AcceptButton = this.btnGiris;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(634, 461);
            this.Controls.Add(this.btnpass);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GirisFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UTK FİTNESS ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.Button btnpass;
    }
}

