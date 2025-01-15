namespace OtelYonetimSistemi
{
    partial class MainForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuDosya = new System.Windows.Forms.ToolStripMenuItem();
            this.menuYonetim = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOdaYonetimi = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMusteriYonetimi = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRezervasyonYonetimi = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRaporlar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDolulukRaporu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGelirRaporu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCikis = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlOdalar = new System.Windows.Forms.Panel();
            this.btnOda = new System.Windows.Forms.Button();
            this.lblOdaDurum = new System.Windows.Forms.Label();
            this.lblAktifRezervasyon = new System.Windows.Forms.Label();
            this.flpOdalar = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlRezervasyonlar = new System.Windows.Forms.Panel();
            this.dgvRezervayonlar = new System.Windows.Forms.DataGridView();
            this.OdaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MusteriAdSoyad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GirisTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CikisTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Durum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.pnlOdalar.SuspendLayout();
            this.flpOdalar.SuspendLayout();
            this.pnlRezervasyonlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervayonlar)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDosya,
            this.menuYonetim,
            this.menuRaporlar,
            this.menuCikis});
            this.menuStrip.Location = new System.Drawing.Point(10, 10);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(1237, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuDosya
            // 
            this.menuDosya.Name = "menuDosya";
            this.menuDosya.Size = new System.Drawing.Size(64, 26);
            this.menuDosya.Text = "Dosya";
            // 
            // menuYonetim
            // 
            this.menuYonetim.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOdaYonetimi,
            this.menuMusteriYonetimi,
            this.menuRezervasyonYonetimi});
            this.menuYonetim.Name = "menuYonetim";
            this.menuYonetim.Size = new System.Drawing.Size(77, 26);
            this.menuYonetim.Text = "Yönetim";
            // 
            // menuOdaYonetimi
            // 
            this.menuOdaYonetimi.Name = "menuOdaYonetimi";
            this.menuOdaYonetimi.Size = new System.Drawing.Size(236, 26);
            this.menuOdaYonetimi.Text = "Oda Yönetimi";
            // 
            // menuMusteriYonetimi
            // 
            this.menuMusteriYonetimi.Name = "menuMusteriYonetimi";
            this.menuMusteriYonetimi.Size = new System.Drawing.Size(236, 26);
            this.menuMusteriYonetimi.Text = "Müşteri Yönetimi";
            // 
            // menuRezervasyonYonetimi
            // 
            this.menuRezervasyonYonetimi.Name = "menuRezervasyonYonetimi";
            this.menuRezervasyonYonetimi.Size = new System.Drawing.Size(236, 26);
            this.menuRezervasyonYonetimi.Text = "Rezervasyon Yönetimi";
            // 
            // menuRaporlar
            // 
            this.menuRaporlar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDolulukRaporu,
            this.menuGelirRaporu});
            this.menuRaporlar.Name = "menuRaporlar";
            this.menuRaporlar.Size = new System.Drawing.Size(80, 26);
            this.menuRaporlar.Text = "Raporlar";
            // 
            // menuDolulukRaporu
            // 
            this.menuDolulukRaporu.Name = "menuDolulukRaporu";
            this.menuDolulukRaporu.Size = new System.Drawing.Size(195, 26);
            this.menuDolulukRaporu.Text = "Doluluk Raporu";
            // 
            // menuGelirRaporu
            // 
            this.menuGelirRaporu.Name = "menuGelirRaporu";
            this.menuGelirRaporu.Size = new System.Drawing.Size(195, 26);
            this.menuGelirRaporu.Text = "Gelir Rapporu";
            // 
            // menuCikis
            // 
            this.menuCikis.Name = "menuCikis";
            this.menuCikis.Size = new System.Drawing.Size(53, 26);
            this.menuCikis.Text = "Çıkış";
            this.menuCikis.Click += new System.EventHandler(this.menuCikis_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(10, 660);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1237, 26);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(70, 20);
            this.lblStatus.Text = "lbl Status";
            // 
            // pnlOdalar
            // 
            this.pnlOdalar.Controls.Add(this.btnOda);
            this.pnlOdalar.Controls.Add(this.lblOdaDurum);
            this.pnlOdalar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlOdalar.Location = new System.Drawing.Point(10, 38);
            this.pnlOdalar.Name = "pnlOdalar";
            this.pnlOdalar.Size = new System.Drawing.Size(302, 622);
            this.pnlOdalar.TabIndex = 3;
            // 
            // btnOda
            // 
            this.btnOda.Location = new System.Drawing.Point(623, 256);
            this.btnOda.Name = "btnOda";
            this.btnOda.Size = new System.Drawing.Size(75, 23);
            this.btnOda.TabIndex = 7;
            this.btnOda.Text = "button1";
            this.btnOda.UseVisualStyleBackColor = true;
            this.btnOda.Click += new System.EventHandler(this.btnOda_Click);
            // 
            // lblOdaDurum
            // 
            this.lblOdaDurum.AutoSize = true;
            this.lblOdaDurum.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOdaDurum.Location = new System.Drawing.Point(55, 24);
            this.lblOdaDurum.Name = "lblOdaDurum";
            this.lblOdaDurum.Size = new System.Drawing.Size(173, 31);
            this.lblOdaDurum.TabIndex = 6;
            this.lblOdaDurum.Text = "Oda Durumları";
            this.lblOdaDurum.Click += new System.EventHandler(this.lblOdaDurum_Click);
            // 
            // lblAktifRezervasyon
            // 
            this.lblAktifRezervasyon.AutoSize = true;
            this.lblAktifRezervasyon.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAktifRezervasyon.Location = new System.Drawing.Point(33, 36);
            this.lblAktifRezervasyon.Name = "lblAktifRezervasyon";
            this.lblAktifRezervasyon.Size = new System.Drawing.Size(235, 31);
            this.lblAktifRezervasyon.TabIndex = 7;
            this.lblAktifRezervasyon.Text = "Aktif Rezervasyonlar";
            this.lblAktifRezervasyon.Click += new System.EventHandler(this.lblAktifRezervasyon_Click);
            // 
            // flpOdalar
            // 
            this.flpOdalar.AutoScroll = true;
            this.flpOdalar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpOdalar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpOdalar.Controls.Add(this.pnlRezervasyonlar);
            this.flpOdalar.Controls.Add(this.dgvRezervayonlar);
            this.flpOdalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpOdalar.Location = new System.Drawing.Point(312, 38);
            this.flpOdalar.Name = "flpOdalar";
            this.flpOdalar.Size = new System.Drawing.Size(935, 622);
            this.flpOdalar.TabIndex = 4;
            // 
            // pnlRezervasyonlar
            // 
            this.pnlRezervasyonlar.Controls.Add(this.lblAktifRezervasyon);
            this.pnlRezervasyonlar.Location = new System.Drawing.Point(3, 3);
            this.pnlRezervasyonlar.Name = "pnlRezervasyonlar";
            this.pnlRezervasyonlar.Padding = new System.Windows.Forms.Padding(10);
            this.pnlRezervasyonlar.Size = new System.Drawing.Size(281, 618);
            this.pnlRezervasyonlar.TabIndex = 4;
            // 
            // dgvRezervayonlar
            // 
            this.dgvRezervayonlar.AllowUserToAddRows = false;
            this.dgvRezervayonlar.AllowUserToDeleteRows = false;
            this.dgvRezervayonlar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRezervayonlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRezervayonlar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OdaNo,
            this.MusteriAdSoyad,
            this.GirisTarihi,
            this.CikisTarihi,
            this.Durum});
            this.dgvRezervayonlar.Location = new System.Drawing.Point(290, 3);
            this.dgvRezervayonlar.MultiSelect = false;
            this.dgvRezervayonlar.Name = "dgvRezervayonlar";
            this.dgvRezervayonlar.ReadOnly = true;
            this.dgvRezervayonlar.RowHeadersWidth = 51;
            this.dgvRezervayonlar.RowTemplate.Height = 24;
            this.dgvRezervayonlar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRezervayonlar.Size = new System.Drawing.Size(611, 615);
            this.dgvRezervayonlar.TabIndex = 5;
            // 
            // OdaNo
            // 
            this.OdaNo.FillWeight = 22.212F;
            this.OdaNo.HeaderText = "Oda No";
            this.OdaNo.MinimumWidth = 20;
            this.OdaNo.Name = "OdaNo";
            this.OdaNo.ReadOnly = true;
            // 
            // MusteriAdSoyad
            // 
            this.MusteriAdSoyad.FillWeight = 106.9519F;
            this.MusteriAdSoyad.HeaderText = "Müşteri";
            this.MusteriAdSoyad.MinimumWidth = 35;
            this.MusteriAdSoyad.Name = "MusteriAdSoyad";
            this.MusteriAdSoyad.ReadOnly = true;
            // 
            // GirisTarihi
            // 
            this.GirisTarihi.FillWeight = 100.7523F;
            this.GirisTarihi.HeaderText = "Giriş Tarihi";
            this.GirisTarihi.MinimumWidth = 6;
            this.GirisTarihi.Name = "GirisTarihi";
            this.GirisTarihi.ReadOnly = true;
            // 
            // CikisTarihi
            // 
            this.CikisTarihi.FillWeight = 84.16649F;
            this.CikisTarihi.HeaderText = "Çıkış Tarihi";
            this.CikisTarihi.MinimumWidth = 6;
            this.CikisTarihi.Name = "CikisTarihi";
            this.CikisTarihi.ReadOnly = true;
            // 
            // Durum
            // 
            this.Durum.FillWeight = 185.9173F;
            this.Durum.HeaderText = "Durum";
            this.Durum.MinimumWidth = 6;
            this.Durum.Name = "Durum";
            this.Durum.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 696);
            this.Controls.Add(this.flpOdalar);
            this.Controls.Add(this.pnlOdalar);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "MainForm";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.pnlOdalar.ResumeLayout(false);
            this.pnlOdalar.PerformLayout();
            this.flpOdalar.ResumeLayout(false);
            this.pnlRezervasyonlar.ResumeLayout(false);
            this.pnlRezervasyonlar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervayonlar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Panel pnlOdalar;
        private System.Windows.Forms.FlowLayoutPanel flpOdalar;
        private System.Windows.Forms.Panel pnlRezervasyonlar;
        private System.Windows.Forms.DataGridView dgvRezervayonlar;
        private System.Windows.Forms.Label lblOdaDurum;
        private System.Windows.Forms.Label lblAktifRezervasyon;
        private System.Windows.Forms.ToolStripMenuItem menuDosya;
        private System.Windows.Forms.ToolStripMenuItem menuYonetim;
        private System.Windows.Forms.ToolStripMenuItem menuRaporlar;
        private System.Windows.Forms.ToolStripMenuItem menuCikis;
        private System.Windows.Forms.ToolStripMenuItem menuOdaYonetimi;
        private System.Windows.Forms.ToolStripMenuItem menuMusteriYonetimi;
        private System.Windows.Forms.ToolStripMenuItem menuRezervasyonYonetimi;
        private System.Windows.Forms.ToolStripMenuItem menuDolulukRaporu;
        private System.Windows.Forms.ToolStripMenuItem menuGelirRaporu;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button btnOda;
        private System.Windows.Forms.DataGridViewTextBoxColumn OdaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MusteriAdSoyad;
        private System.Windows.Forms.DataGridViewTextBoxColumn GirisTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn CikisTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Durum;
    }
}