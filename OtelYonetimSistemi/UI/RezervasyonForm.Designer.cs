namespace OtelYonetimSistemi.UI
{
    partial class RezervasyonForm
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
            this.dtpGirisTarihi = new System.Windows.Forms.DateTimePicker();
            this.dtpCikisTarihi = new System.Windows.Forms.DateTimePicker();
            this.cmbOdaTipi = new System.Windows.Forms.ComboBox();
            this.txtAdSoyad = new System.Windows.Forms.TextBox();
            this.btnRezervasyonYap = new System.Windows.Forms.Button();
            this.txtTelNumarasi = new System.Windows.Forms.TextBox();
            this.lblAdSoyad = new System.Windows.Forms.Label();
            this.lblTelNumarasi = new System.Windows.Forms.Label();
            this.lblOdaTipi = new System.Windows.Forms.Label();
            this.rtbOzet = new System.Windows.Forms.RichTextBox();
            this.lblOzet = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpGirisTarihi
            // 
            this.dtpGirisTarihi.Location = new System.Drawing.Point(576, 144);
            this.dtpGirisTarihi.Name = "dtpGirisTarihi";
            this.dtpGirisTarihi.Size = new System.Drawing.Size(214, 22);
            this.dtpGirisTarihi.TabIndex = 0;
            // 
            // dtpCikisTarihi
            // 
            this.dtpCikisTarihi.Location = new System.Drawing.Point(576, 200);
            this.dtpCikisTarihi.Name = "dtpCikisTarihi";
            this.dtpCikisTarihi.Size = new System.Drawing.Size(214, 22);
            this.dtpCikisTarihi.TabIndex = 1;
            // 
            // cmbOdaTipi
            // 
            this.cmbOdaTipi.FormattingEnabled = true;
            this.cmbOdaTipi.Items.AddRange(new object[] {
            "Tek Kişilik",
            "Çift Kişilik",
            "Dört Kişilik",
            "Süit"});
            this.cmbOdaTipi.Location = new System.Drawing.Point(195, 269);
            this.cmbOdaTipi.Name = "cmbOdaTipi";
            this.cmbOdaTipi.Size = new System.Drawing.Size(135, 24);
            this.cmbOdaTipi.TabIndex = 2;
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.Location = new System.Drawing.Point(195, 145);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Size = new System.Drawing.Size(233, 22);
            this.txtAdSoyad.TabIndex = 3;
            // 
            // btnRezervasyonYap
            // 
            this.btnRezervasyonYap.Location = new System.Drawing.Point(601, 272);
            this.btnRezervasyonYap.Name = "btnRezervasyonYap";
            this.btnRezervasyonYap.Size = new System.Drawing.Size(156, 42);
            this.btnRezervasyonYap.TabIndex = 5;
            this.btnRezervasyonYap.Text = "Rezervasyon Yap";
            this.btnRezervasyonYap.UseVisualStyleBackColor = true;
            this.btnRezervasyonYap.Click += new System.EventHandler(this.btnRezervasyonYap_Click);
            // 
            // txtTelNumarasi
            // 
            this.txtTelNumarasi.Location = new System.Drawing.Point(195, 208);
            this.txtTelNumarasi.Name = "txtTelNumarasi";
            this.txtTelNumarasi.Size = new System.Drawing.Size(233, 22);
            this.txtTelNumarasi.TabIndex = 6;
            // 
            // lblAdSoyad
            // 
            this.lblAdSoyad.AutoSize = true;
            this.lblAdSoyad.Location = new System.Drawing.Point(65, 148);
            this.lblAdSoyad.Name = "lblAdSoyad";
            this.lblAdSoyad.Size = new System.Drawing.Size(113, 16);
            this.lblAdSoyad.TabIndex = 7;
            this.lblAdSoyad.Text = "Müşteri Ad Soyad";
            // 
            // lblTelNumarasi
            // 
            this.lblTelNumarasi.AutoSize = true;
            this.lblTelNumarasi.Location = new System.Drawing.Point(65, 214);
            this.lblTelNumarasi.Name = "lblTelNumarasi";
            this.lblTelNumarasi.Size = new System.Drawing.Size(114, 16);
            this.lblTelNumarasi.TabIndex = 8;
            this.lblTelNumarasi.Text = "Telefon Numarası";
            // 
            // lblOdaTipi
            // 
            this.lblOdaTipi.AutoSize = true;
            this.lblOdaTipi.Location = new System.Drawing.Point(106, 272);
            this.lblOdaTipi.Name = "lblOdaTipi";
            this.lblOdaTipi.Size = new System.Drawing.Size(59, 16);
            this.lblOdaTipi.TabIndex = 9;
            this.lblOdaTipi.Text = "Oda Tipi";
            // 
            // rtbOzet
            // 
            this.rtbOzet.Location = new System.Drawing.Point(879, 127);
            this.rtbOzet.Name = "rtbOzet";
            this.rtbOzet.Size = new System.Drawing.Size(210, 217);
            this.rtbOzet.TabIndex = 10;
            this.rtbOzet.Text = "";
            // 
            // lblOzet
            // 
            this.lblOzet.AutoSize = true;
            this.lblOzet.Location = new System.Drawing.Point(885, 108);
            this.lblOzet.Name = "lblOzet";
            this.lblOzet.Size = new System.Drawing.Size(66, 16);
            this.lblOzet.TabIndex = 11;
            this.lblOzet.Text = "Son İşlem";
            // 
            // RezervasyonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 608);
            this.Controls.Add(this.lblOzet);
            this.Controls.Add(this.rtbOzet);
            this.Controls.Add(this.lblOdaTipi);
            this.Controls.Add(this.lblTelNumarasi);
            this.Controls.Add(this.lblAdSoyad);
            this.Controls.Add(this.txtTelNumarasi);
            this.Controls.Add(this.btnRezervasyonYap);
            this.Controls.Add(this.txtAdSoyad);
            this.Controls.Add(this.cmbOdaTipi);
            this.Controls.Add(this.dtpCikisTarihi);
            this.Controls.Add(this.dtpGirisTarihi);
            this.Name = "RezervasyonForm";
            this.Text = "RezervasyonDetayForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpGirisTarihi;
        private System.Windows.Forms.DateTimePicker dtpCikisTarihi;
        private System.Windows.Forms.ComboBox cmbOdaTipi;
        private System.Windows.Forms.TextBox txtAdSoyad;
        private System.Windows.Forms.Button btnRezervasyonYap;
        private System.Windows.Forms.TextBox txtTelNumarasi;
        private System.Windows.Forms.Label lblAdSoyad;
        private System.Windows.Forms.Label lblTelNumarasi;
        private System.Windows.Forms.Label lblOdaTipi;
        private System.Windows.Forms.RichTextBox rtbOzet;
        private System.Windows.Forms.Label lblOzet;
    }
}