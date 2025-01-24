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
            this.dgvGenel = new System.Windows.Forms.DataGridView();
            this.dgvOda = new System.Windows.Forms.DataGridView();
            this.btnOdaYenile = new System.Windows.Forms.Button();
            this.btnRezervasyon = new System.Windows.Forms.Button();
            this.statusLabelDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOda)).BeginInit();
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
            this.menuStrip.Size = new System.Drawing.Size(1112, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuDosya
            // 
            this.menuDosya.Name = "menuDosya";
            this.menuDosya.Size = new System.Drawing.Size(64, 24);
            this.menuDosya.Text = "Dosya";
            // 
            // menuYonetim
            // 
            this.menuYonetim.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOdaYonetimi,
            this.menuMusteriYonetimi,
            this.menuRezervasyonYonetimi});
            this.menuYonetim.Name = "menuYonetim";
            this.menuYonetim.Size = new System.Drawing.Size(77, 24);
            this.menuYonetim.Text = "Yönetim";
            // 
            // menuOdaYonetimi
            // 
            this.menuOdaYonetimi.Name = "menuOdaYonetimi";
            this.menuOdaYonetimi.Size = new System.Drawing.Size(236, 26);
            this.menuOdaYonetimi.Text = "Oda Yönetimi";
            this.menuOdaYonetimi.Click += new System.EventHandler(this.menuOdaYonetimi_Click);
            // 
            // menuMusteriYonetimi
            // 
            this.menuMusteriYonetimi.Name = "menuMusteriYonetimi";
            this.menuMusteriYonetimi.Size = new System.Drawing.Size(236, 26);
            this.menuMusteriYonetimi.Text = "Müşteri Yönetimi";
            this.menuMusteriYonetimi.Click += new System.EventHandler(this.menuMusteriYonetimi_Click);
            // 
            // menuRezervasyonYonetimi
            // 
            this.menuRezervasyonYonetimi.Name = "menuRezervasyonYonetimi";
            this.menuRezervasyonYonetimi.Size = new System.Drawing.Size(236, 26);
            this.menuRezervasyonYonetimi.Text = "Rezervasyon Yönetimi";
            this.menuRezervasyonYonetimi.Click += new System.EventHandler(this.menuRezervasyonYonetimi_Click);
            // 
            // menuRaporlar
            // 
            this.menuRaporlar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDolulukRaporu,
            this.menuGelirRaporu});
            this.menuRaporlar.Name = "menuRaporlar";
            this.menuRaporlar.Size = new System.Drawing.Size(80, 24);
            this.menuRaporlar.Text = "Raporlar";
            // 
            // menuDolulukRaporu
            // 
            this.menuDolulukRaporu.Name = "menuDolulukRaporu";
            this.menuDolulukRaporu.Size = new System.Drawing.Size(224, 26);
            this.menuDolulukRaporu.Text = "Doluluk Raporu";
            this.menuDolulukRaporu.Click += new System.EventHandler(this.menuDolulukRaporu_Click);
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
            this.menuCikis.Size = new System.Drawing.Size(53, 24);
            this.menuCikis.Text = "Çıkış";
            this.menuCikis.Click += new System.EventHandler(this.menuCikis_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelDateTime});
            this.statusStrip.Location = new System.Drawing.Point(10, 623);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1112, 26);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // dgvGenel
            // 
            this.dgvGenel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGenel.Location = new System.Drawing.Point(601, 44);
            this.dgvGenel.Name = "dgvGenel";
            this.dgvGenel.RowHeadersWidth = 51;
            this.dgvGenel.RowTemplate.Height = 24;
            this.dgvGenel.Size = new System.Drawing.Size(508, 407);
            this.dgvGenel.TabIndex = 5;
            this.dgvGenel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGenel_CellContentClick);
            // 
            // dgvOda
            // 
            this.dgvOda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOda.Location = new System.Drawing.Point(13, 44);
            this.dgvOda.Name = "dgvOda";
            this.dgvOda.RowHeadersWidth = 51;
            this.dgvOda.RowTemplate.Height = 24;
            this.dgvOda.Size = new System.Drawing.Size(521, 407);
            this.dgvOda.TabIndex = 6;
            // 
            // btnOdaYenile
            // 
            this.btnOdaYenile.Location = new System.Drawing.Point(13, 468);
            this.btnOdaYenile.Name = "btnOdaYenile";
            this.btnOdaYenile.Size = new System.Drawing.Size(185, 31);
            this.btnOdaYenile.TabIndex = 7;
            this.btnOdaYenile.Text = "Oda Tablosunu Güncelle";
            this.btnOdaYenile.UseVisualStyleBackColor = true;
            this.btnOdaYenile.Click += new System.EventHandler(this.btnOdaYenile_Click);
            // 
            // btnRezervasyon
            // 
            this.btnRezervasyon.Location = new System.Drawing.Point(601, 468);
            this.btnRezervasyon.Name = "btnRezervasyon";
            this.btnRezervasyon.Size = new System.Drawing.Size(240, 31);
            this.btnRezervasyon.TabIndex = 8;
            this.btnRezervasyon.Text = "Rezervasyon Tablosunu Güncelle";
            this.btnRezervasyon.UseVisualStyleBackColor = true;
            this.btnRezervasyon.Click += new System.EventHandler(this.btnRezervasyon_Click);
            // 
            // statusLabelDateTime
            // 
            this.statusLabelDateTime.Name = "statusLabelDateTime";
            this.statusLabelDateTime.Size = new System.Drawing.Size(151, 20);
            this.statusLabelDateTime.Text = "toolStripStatusLabel1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 659);
            this.Controls.Add(this.btnRezervasyon);
            this.Controls.Add(this.btnOdaYenile);
            this.Controls.Add(this.dgvOda);
            this.Controls.Add(this.dgvGenel);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem menuDosya;
        private System.Windows.Forms.ToolStripMenuItem menuYonetim;
        private System.Windows.Forms.ToolStripMenuItem menuRaporlar;
        private System.Windows.Forms.ToolStripMenuItem menuCikis;
        private System.Windows.Forms.ToolStripMenuItem menuOdaYonetimi;
        private System.Windows.Forms.ToolStripMenuItem menuMusteriYonetimi;
        private System.Windows.Forms.ToolStripMenuItem menuRezervasyonYonetimi;
        private System.Windows.Forms.ToolStripMenuItem menuDolulukRaporu;
        private System.Windows.Forms.ToolStripMenuItem menuGelirRaporu;
        private System.Windows.Forms.DataGridView dgvGenel;
        private System.Windows.Forms.DataGridView dgvOda;
        private System.Windows.Forms.Button btnOdaYenile;
        private System.Windows.Forms.Button btnRezervasyon;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelDateTime;
    }
}