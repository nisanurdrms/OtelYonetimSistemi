namespace OtelYonetimSistemi.UI
{
    partial class OdaDetayForm
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
            this.pnlBilgi = new System.Windows.Forms.Panel();
            this.pnlIslemler = new System.Windows.Forms.Panel();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.lblOdaNo = new System.Windows.Forms.Label();
            this.lblOdaTipi = new System.Windows.Forms.Label();
            this.lblDurum = new System.Windows.Forms.Label();
            this.lblTemizlik = new System.Windows.Forms.Label();
            this.btnRezervasyonYap = new System.Windows.Forms.Button();
            this.btnTemizlik = new System.Windows.Forms.Button();
            this.btnCikisYap = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.grpMevcut = new System.Windows.Forms.GroupBox();
            this.lblMevcutMusteri = new System.Windows.Forms.Label();
            this.lblGirisTarihi = new System.Windows.Forms.Label();
            this.lblCikisTarihi = new System.Windows.Forms.Label();
            this.lblOdaDetaylari = new System.Windows.Forms.Label();
            this.tblBilgi = new System.Windows.Forms.TableLayoutPanel();
            this.tblMevcutKontrol = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBilgi.SuspendLayout();
            this.pnlIslemler.SuspendLayout();
            this.grpMevcut.SuspendLayout();
            this.tblBilgi.SuspendLayout();
            this.tblMevcutKontrol.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBilgi
            // 
            this.pnlBilgi.BackColor = System.Drawing.Color.White;
            this.pnlBilgi.Controls.Add(this.lblBaslik);
            this.pnlBilgi.Controls.Add(this.tblBilgi);
            this.pnlBilgi.Controls.Add(this.lblOdaDetaylari);
            this.pnlBilgi.Controls.Add(this.grpMevcut);
            this.pnlBilgi.Controls.Add(this.pnlIslemler);
            this.pnlBilgi.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBilgi.Location = new System.Drawing.Point(0, 0);
            this.pnlBilgi.Name = "pnlBilgi";
            this.pnlBilgi.Padding = new System.Windows.Forms.Padding(20);
            this.pnlBilgi.Size = new System.Drawing.Size(1275, 769);
            this.pnlBilgi.TabIndex = 0;
            this.pnlBilgi.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBilgi_Paint);
            // 
            // pnlIslemler
            // 
            this.pnlIslemler.Controls.Add(this.btnRezervasyonYap);
            this.pnlIslemler.Controls.Add(this.btnTemizlik);
            this.pnlIslemler.Controls.Add(this.btnIptal);
            this.pnlIslemler.Controls.Add(this.btnCikisYap);
            this.pnlIslemler.Location = new System.Drawing.Point(368, 524);
            this.pnlIslemler.Name = "pnlIslemler";
            this.pnlIslemler.Padding = new System.Windows.Forms.Padding(20);
            this.pnlIslemler.Size = new System.Drawing.Size(538, 147);
            this.pnlIslemler.TabIndex = 1;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Location = new System.Drawing.Point(628, 150);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(44, 16);
            this.lblBaslik.TabIndex = 2;
            this.lblBaslik.Text = "label1";
            // 
            // lblOdaNo
            // 
            this.lblOdaNo.AutoSize = true;
            this.lblOdaNo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOdaNo.Location = new System.Drawing.Point(13, 10);
            this.lblOdaNo.Name = "lblOdaNo";
            this.lblOdaNo.Size = new System.Drawing.Size(124, 23);
            this.lblOdaNo.TabIndex = 3;
            this.lblOdaNo.Text = "Oda Numarası";
            this.lblOdaNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOdaTipi
            // 
            this.lblOdaTipi.AutoSize = true;
            this.lblOdaTipi.BackColor = System.Drawing.Color.Transparent;
            this.lblOdaTipi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOdaTipi.Location = new System.Drawing.Point(13, 77);
            this.lblOdaTipi.Name = "lblOdaTipi";
            this.lblOdaTipi.Size = new System.Drawing.Size(79, 23);
            this.lblOdaTipi.TabIndex = 4;
            this.lblOdaTipi.Text = "Oda Tipi";
            this.lblOdaTipi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDurum.Location = new System.Drawing.Point(13, 144);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(66, 23);
            this.lblDurum.TabIndex = 5;
            this.lblDurum.Text = "Durum";
            // 
            // lblTemizlik
            // 
            this.lblTemizlik.AutoSize = true;
            this.lblTemizlik.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTemizlik.Location = new System.Drawing.Point(13, 211);
            this.lblTemizlik.Name = "lblTemizlik";
            this.lblTemizlik.Size = new System.Drawing.Size(76, 23);
            this.lblTemizlik.TabIndex = 6;
            this.lblTemizlik.Text = "Temizlik";
            // 
            // btnRezervasyonYap
            // 
            this.btnRezervasyonYap.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRezervasyonYap.Location = new System.Drawing.Point(25, 97);
            this.btnRezervasyonYap.Margin = new System.Windows.Forms.Padding(5);
            this.btnRezervasyonYap.Name = "btnRezervasyonYap";
            this.btnRezervasyonYap.Size = new System.Drawing.Size(183, 40);
            this.btnRezervasyonYap.TabIndex = 7;
            this.btnRezervasyonYap.Text = "Rezervasyon Yap";
            this.btnRezervasyonYap.UseVisualStyleBackColor = true;
            // 
            // btnTemizlik
            // 
            this.btnTemizlik.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizlik.Location = new System.Drawing.Point(25, 23);
            this.btnTemizlik.Name = "btnTemizlik";
            this.btnTemizlik.Size = new System.Drawing.Size(183, 59);
            this.btnTemizlik.TabIndex = 8;
            this.btnTemizlik.Text = "Temizlik Durumunu Güncelle";
            this.btnTemizlik.UseVisualStyleBackColor = true;
            // 
            // btnCikisYap
            // 
            this.btnCikisYap.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCikisYap.Location = new System.Drawing.Point(301, 32);
            this.btnCikisYap.Name = "btnCikisYap";
            this.btnCikisYap.Size = new System.Drawing.Size(183, 41);
            this.btnCikisYap.TabIndex = 9;
            this.btnCikisYap.Text = "Çıkış İşlemi";
            this.btnCikisYap.UseVisualStyleBackColor = true;
            // 
            // btnIptal
            // 
            this.btnIptal.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIptal.Location = new System.Drawing.Point(301, 97);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(183, 40);
            this.btnIptal.TabIndex = 10;
            this.btnIptal.Text = "Kapat";
            this.btnIptal.UseVisualStyleBackColor = true;
            // 
            // grpMevcut
            // 
            this.grpMevcut.Controls.Add(this.tblMevcutKontrol);
            this.grpMevcut.Location = new System.Drawing.Point(29, 123);
            this.grpMevcut.Margin = new System.Windows.Forms.Padding(20);
            this.grpMevcut.Name = "grpMevcut";
            this.grpMevcut.Padding = new System.Windows.Forms.Padding(10);
            this.grpMevcut.Size = new System.Drawing.Size(448, 328);
            this.grpMevcut.TabIndex = 11;
            this.grpMevcut.TabStop = false;
            this.grpMevcut.Text = "Mevcut Müşteri Bilgileri";
            // 
            // lblMevcutMusteri
            // 
            this.lblMevcutMusteri.AutoSize = true;
            this.lblMevcutMusteri.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMevcutMusteri.Location = new System.Drawing.Point(3, 0);
            this.lblMevcutMusteri.Name = "lblMevcutMusteri";
            this.lblMevcutMusteri.Size = new System.Drawing.Size(76, 23);
            this.lblMevcutMusteri.TabIndex = 12;
            this.lblMevcutMusteri.Text = "Müşteri:";
            // 
            // lblGirisTarihi
            // 
            this.lblGirisTarihi.AutoSize = true;
            this.lblGirisTarihi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGirisTarihi.Location = new System.Drawing.Point(3, 76);
            this.lblGirisTarihi.Name = "lblGirisTarihi";
            this.lblGirisTarihi.Size = new System.Drawing.Size(96, 23);
            this.lblGirisTarihi.TabIndex = 13;
            this.lblGirisTarihi.Text = "Giriş Tarihi";
            // 
            // lblCikisTarihi
            // 
            this.lblCikisTarihi.AutoSize = true;
            this.lblCikisTarihi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCikisTarihi.Location = new System.Drawing.Point(3, 152);
            this.lblCikisTarihi.Name = "lblCikisTarihi";
            this.lblCikisTarihi.Size = new System.Drawing.Size(98, 23);
            this.lblCikisTarihi.TabIndex = 14;
            this.lblCikisTarihi.Text = "Çıkış Tarihi";
            this.lblCikisTarihi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOdaDetaylari
            // 
            this.lblOdaDetaylari.AutoSize = true;
            this.lblOdaDetaylari.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOdaDetaylari.Location = new System.Drawing.Point(500, 20);
            this.lblOdaDetaylari.Name = "lblOdaDetaylari";
            this.lblOdaDetaylari.Size = new System.Drawing.Size(230, 38);
            this.lblOdaDetaylari.TabIndex = 15;
            this.lblOdaDetaylari.Text = "Oda Detayları";
            // 
            // tblBilgi
            // 
            this.tblBilgi.ColumnCount = 2;
            this.tblBilgi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBilgi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblBilgi.Controls.Add(this.lblOdaNo, 0, 0);
            this.tblBilgi.Controls.Add(this.lblOdaTipi, 0, 1);
            this.tblBilgi.Controls.Add(this.lblDurum, 0, 2);
            this.tblBilgi.Controls.Add(this.lblTemizlik, 0, 3);
            this.tblBilgi.Location = new System.Drawing.Point(760, 123);
            this.tblBilgi.Name = "tblBilgi";
            this.tblBilgi.Padding = new System.Windows.Forms.Padding(10);
            this.tblBilgi.RowCount = 4;
            this.tblBilgi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblBilgi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblBilgi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblBilgi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblBilgi.Size = new System.Drawing.Size(438, 290);
            this.tblBilgi.TabIndex = 16;
            // 
            // tblMevcutKontrol
            // 
            this.tblMevcutKontrol.ColumnCount = 2;
            this.tblMevcutKontrol.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMevcutKontrol.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMevcutKontrol.Controls.Add(this.lblGirisTarihi, 0, 1);
            this.tblMevcutKontrol.Controls.Add(this.lblCikisTarihi, 0, 2);
            this.tblMevcutKontrol.Controls.Add(this.lblMevcutMusteri, 0, 0);
            this.tblMevcutKontrol.Location = new System.Drawing.Point(13, 47);
            this.tblMevcutKontrol.Name = "tblMevcutKontrol";
            this.tblMevcutKontrol.RowCount = 3;
            this.tblMevcutKontrol.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblMevcutKontrol.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblMevcutKontrol.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblMevcutKontrol.Size = new System.Drawing.Size(422, 230);
            this.tblMevcutKontrol.TabIndex = 16;
            this.tblMevcutKontrol.Paint += new System.Windows.Forms.PaintEventHandler(this.tblMevcutKontrol_Paint);
            // 
            // OdaDetayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 765);
            this.Controls.Add(this.pnlBilgi);
            this.Name = "OdaDetayForm";
            this.Text = "OdaDetayForm";
            this.Load += new System.EventHandler(this.OdaDetayForm_Load);
            this.pnlBilgi.ResumeLayout(false);
            this.pnlBilgi.PerformLayout();
            this.pnlIslemler.ResumeLayout(false);
            this.grpMevcut.ResumeLayout(false);
            this.tblBilgi.ResumeLayout(false);
            this.tblBilgi.PerformLayout();
            this.tblMevcutKontrol.ResumeLayout(false);
            this.tblMevcutKontrol.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBilgi;
        private System.Windows.Forms.Panel pnlIslemler;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label lblOdaNo;
        private System.Windows.Forms.Label lblOdaTipi;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.Label lblTemizlik;
        private System.Windows.Forms.Button btnRezervasyonYap;
        private System.Windows.Forms.Button btnTemizlik;
        private System.Windows.Forms.Button btnCikisYap;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.GroupBox grpMevcut;
        private System.Windows.Forms.Label lblMevcutMusteri;
        private System.Windows.Forms.Label lblGirisTarihi;
        private System.Windows.Forms.Label lblCikisTarihi;
        private System.Windows.Forms.Label lblOdaDetaylari;
        private System.Windows.Forms.TableLayoutPanel tblBilgi;
        private System.Windows.Forms.TableLayoutPanel tblMevcutKontrol;
    }
}