namespace utkfitnes
{
    partial class AdminPaneli
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPaneli));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvuyelertable = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmboxaylık = new System.Windows.Forms.ComboBox();
            this.btntemizle = new System.Windows.Forms.Button();
            this.telnoTextBox = new System.Windows.Forms.TextBox();
            this.yasTextBox = new System.Windows.Forms.TextBox();
            this.soyadTextBox = new System.Windows.Forms.TextBox();
            this.adTextBox = new System.Windows.Forms.TextBox();
            this.ekleButton = new System.Windows.Forms.Button();
            this.silButton = new System.Windows.Forms.Button();
            this.guncelleButton = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnformreset = new System.Windows.Forms.Button();
            this.btnsil = new System.Windows.Forms.Button();
            this.btngnc = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.cmboxRol = new System.Windows.Forms.ComboBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabControl1.Location = new System.Drawing.Point(-1, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(934, 500);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage2.BackgroundImage")));
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.lvuyelertable);
            this.tabPage2.Controls.Add(this.cmboxaylık);
            this.tabPage2.Controls.Add(this.btntemizle);
            this.tabPage2.Controls.Add(this.telnoTextBox);
            this.tabPage2.Controls.Add(this.yasTextBox);
            this.tabPage2.Controls.Add(this.soyadTextBox);
            this.tabPage2.Controls.Add(this.adTextBox);
            this.tabPage2.Controls.Add(this.ekleButton);
            this.tabPage2.Controls.Add(this.silButton);
            this.tabPage2.Controls.Add(this.guncelleButton);
            this.tabPage2.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(926, 474);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Üye Listesi";
            // 
            // lvuyelertable
            // 
            this.lvuyelertable.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lvuyelertable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvuyelertable.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lvuyelertable.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvuyelertable.HideSelection = false;
            this.lvuyelertable.Location = new System.Drawing.Point(485, 117);
            this.lvuyelertable.Name = "lvuyelertable";
            this.lvuyelertable.Size = new System.Drawing.Size(385, 136);
            this.lvuyelertable.TabIndex = 1;
            this.lvuyelertable.TabStop = false;
            this.lvuyelertable.UseCompatibleStateImageBehavior = false;
            this.lvuyelertable.View = System.Windows.Forms.View.Details;
            this.lvuyelertable.SelectedIndexChanged += new System.EventHandler(this.lvuyelertable_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Üye ID";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ad";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Soyad";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Yaş";
            this.columnHeader4.Width = 30;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Telefon";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Üyelik Süresi";
            this.columnHeader6.Width = 80;
            // 
            // cmboxaylık
            // 
            this.cmboxaylık.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmboxaylık.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmboxaylık.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmboxaylık.FormattingEnabled = true;
            this.cmboxaylık.Items.AddRange(new object[] {
            "1 ",
            "3",
            "6",
            "12"});
            this.cmboxaylık.Location = new System.Drawing.Point(77, 290);
            this.cmboxaylık.Name = "cmboxaylık";
            this.cmboxaylık.Size = new System.Drawing.Size(155, 21);
            this.cmboxaylık.TabIndex = 8;
            // 
            // btntemizle
            // 
            this.btntemizle.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btntemizle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btntemizle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btntemizle.Location = new System.Drawing.Point(256, 250);
            this.btntemizle.Name = "btntemizle";
            this.btntemizle.Size = new System.Drawing.Size(100, 23);
            this.btntemizle.TabIndex = 7;
            this.btntemizle.TabStop = false;
            this.btntemizle.Text = "Formu Temizle";
            this.btntemizle.UseVisualStyleBackColor = false;
            this.btntemizle.Click += new System.EventHandler(this.btntemizle_Click);
            // 
            // telnoTextBox
            // 
            this.telnoTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.telnoTextBox.Location = new System.Drawing.Point(77, 250);
            this.telnoTextBox.Name = "telnoTextBox";
            this.telnoTextBox.Size = new System.Drawing.Size(155, 22);
            this.telnoTextBox.TabIndex = 3;
            // 
            // yasTextBox
            // 
            this.yasTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.yasTextBox.Location = new System.Drawing.Point(77, 211);
            this.yasTextBox.Name = "yasTextBox";
            this.yasTextBox.Size = new System.Drawing.Size(155, 22);
            this.yasTextBox.TabIndex = 2;
            // 
            // soyadTextBox
            // 
            this.soyadTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.soyadTextBox.Location = new System.Drawing.Point(77, 168);
            this.soyadTextBox.Name = "soyadTextBox";
            this.soyadTextBox.Size = new System.Drawing.Size(155, 22);
            this.soyadTextBox.TabIndex = 1;
            // 
            // adTextBox
            // 
            this.adTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.adTextBox.Location = new System.Drawing.Point(77, 132);
            this.adTextBox.Name = "adTextBox";
            this.adTextBox.Size = new System.Drawing.Size(155, 22);
            this.adTextBox.TabIndex = 0;
            // 
            // ekleButton
            // 
            this.ekleButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ekleButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ekleButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ekleButton.Location = new System.Drawing.Point(256, 128);
            this.ekleButton.Name = "ekleButton";
            this.ekleButton.Size = new System.Drawing.Size(100, 26);
            this.ekleButton.TabIndex = 4;
            this.ekleButton.TabStop = false;
            this.ekleButton.Text = "Ekle";
            this.ekleButton.UseVisualStyleBackColor = false;
            this.ekleButton.Click += new System.EventHandler(this.ekleButton_Click);
            // 
            // silButton
            // 
            this.silButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.silButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.silButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.silButton.Location = new System.Drawing.Point(256, 211);
            this.silButton.Name = "silButton";
            this.silButton.Size = new System.Drawing.Size(100, 23);
            this.silButton.TabIndex = 6;
            this.silButton.TabStop = false;
            this.silButton.Text = "Sil";
            this.silButton.UseVisualStyleBackColor = false;
            this.silButton.Click += new System.EventHandler(this.silButton_Click);
            // 
            // guncelleButton
            // 
            this.guncelleButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.guncelleButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.guncelleButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.guncelleButton.Location = new System.Drawing.Point(256, 168);
            this.guncelleButton.Name = "guncelleButton";
            this.guncelleButton.Size = new System.Drawing.Size(100, 25);
            this.guncelleButton.TabIndex = 5;
            this.guncelleButton.TabStop = false;
            this.guncelleButton.Text = "Güncelle";
            this.guncelleButton.UseVisualStyleBackColor = false;
            this.guncelleButton.Click += new System.EventHandler(this.guncelleButton_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage1.BackgroundImage")));
            this.tabPage1.Controls.Add(this.btnformreset);
            this.tabPage1.Controls.Add(this.btnsil);
            this.tabPage1.Controls.Add(this.btngnc);
            this.tabPage1.Controls.Add(this.btnEkle);
            this.tabPage1.Controls.Add(this.cmboxRol);
            this.tabPage1.Controls.Add(this.txtSifre);
            this.tabPage1.Controls.Add(this.txtAd);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(926, 474);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Kullanıcı Yönetimi";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnformreset
            // 
            this.btnformreset.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnformreset.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnformreset.Location = new System.Drawing.Point(109, 287);
            this.btnformreset.Name = "btnformreset";
            this.btnformreset.Size = new System.Drawing.Size(104, 35);
            this.btnformreset.TabIndex = 8;
            this.btnformreset.TabStop = false;
            this.btnformreset.Text = "Formu Temizle";
            this.btnformreset.UseVisualStyleBackColor = false;
            this.btnformreset.Click += new System.EventHandler(this.btnformreset_Click);
            // 
            // btnsil
            // 
            this.btnsil.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnsil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnsil.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnsil.Location = new System.Drawing.Point(241, 261);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(96, 34);
            this.btnsil.TabIndex = 5;
            this.btnsil.TabStop = false;
            this.btnsil.Text = "Sil";
            this.btnsil.UseVisualStyleBackColor = false;
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // btngnc
            // 
            this.btngnc.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btngnc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btngnc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btngnc.Location = new System.Drawing.Point(241, 209);
            this.btngnc.Name = "btngnc";
            this.btngnc.Size = new System.Drawing.Size(96, 34);
            this.btngnc.TabIndex = 4;
            this.btngnc.TabStop = false;
            this.btngnc.Text = "Güncelle";
            this.btngnc.UseVisualStyleBackColor = false;
            this.btngnc.Click += new System.EventHandler(this.btngnc_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEkle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.Location = new System.Drawing.Point(241, 154);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(96, 34);
            this.btnEkle.TabIndex = 3;
            this.btnEkle.TabStop = false;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // cmboxRol
            // 
            this.cmboxRol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmboxRol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmboxRol.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cmboxRol.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboxRol.FormattingEnabled = true;
            this.cmboxRol.Items.AddRange(new object[] {
            "Yönetici",
            "Personel"});
            this.cmboxRol.Location = new System.Drawing.Point(78, 249);
            this.cmboxRol.Name = "cmboxRol";
            this.cmboxRol.Size = new System.Drawing.Size(135, 21);
            this.cmboxRol.TabIndex = 2;
            // 
            // txtSifre
            // 
            this.txtSifre.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtSifre.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSifre.Location = new System.Drawing.Point(78, 209);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(135, 22);
            this.txtSifre.TabIndex = 1;
            // 
            // txtAd
            // 
            this.txtAd.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtAd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAd.Location = new System.Drawing.Point(78, 166);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(135, 22);
            this.txtAd.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(637, 149);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(235, 186);
            this.listView1.TabIndex = 0;
            this.listView1.TabStop = false;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Kullanıcı Adı";
            this.columnHeader7.Width = 80;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Şifre";
            this.columnHeader8.Width = 80;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Rol";
            // 
            // AdminPaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(930, 497);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "AdminPaneli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UTK FİTNESS Admin Paneli";
            this.Load += new System.EventHandler(this.AdminPaneli_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox cmboxRol;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Button btnsil;
        private System.Windows.Forms.Button btngnc;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.TextBox soyadTextBox;
        private System.Windows.Forms.TextBox adTextBox;
        private System.Windows.Forms.Button ekleButton;
        private System.Windows.Forms.Button silButton;
        private System.Windows.Forms.Button guncelleButton;
        private System.Windows.Forms.TextBox telnoTextBox;
        private System.Windows.Forms.TextBox yasTextBox;
        private System.Windows.Forms.Button btntemizle;
        private System.Windows.Forms.Button btnformreset;
        private System.Windows.Forms.ComboBox cmboxaylık;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ListView lvuyelertable;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}