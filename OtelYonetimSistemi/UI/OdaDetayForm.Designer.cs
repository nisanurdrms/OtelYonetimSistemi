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
            this.dgvOdaListesi = new System.Windows.Forms.DataGridView();
            this.txtOdaNumarasi = new System.Windows.Forms.TextBox();
            this.numToplamTutar = new System.Windows.Forms.NumericUpDown();
            this.btnOdaEkle = new System.Windows.Forms.Button();
            this.btnOdaSil = new System.Windows.Forms.Button();
            this.btnOdaTemizlik = new System.Windows.Forms.Button();
            this.lblOdaİslemleri = new System.Windows.Forms.Label();
            this.btnMusaitlikDolulukDurumuu = new System.Windows.Forms.Button();
            this.lblOdaNumarasi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOdaTipi = new System.Windows.Forms.TextBox();
            this.txtToplamTutar = new System.Windows.Forms.TextBox();
            this.lblOdaFiyati = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdaListesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToplamTutar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOdaListesi
            // 
            this.dgvOdaListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOdaListesi.Location = new System.Drawing.Point(122, 298);
            this.dgvOdaListesi.Name = "dgvOdaListesi";
            this.dgvOdaListesi.RowHeadersWidth = 51;
            this.dgvOdaListesi.RowTemplate.Height = 24;
            this.dgvOdaListesi.Size = new System.Drawing.Size(831, 311);
            this.dgvOdaListesi.TabIndex = 0;
            // 
            // txtOdaNumarasi
            // 
            this.txtOdaNumarasi.Location = new System.Drawing.Point(164, 108);
            this.txtOdaNumarasi.Name = "txtOdaNumarasi";
            this.txtOdaNumarasi.Size = new System.Drawing.Size(100, 22);
            this.txtOdaNumarasi.TabIndex = 1;
            // 
            // numToplamTutar
            // 
            this.numToplamTutar.Location = new System.Drawing.Point(165, 305);
            this.numToplamTutar.Name = "numToplamTutar";
            this.numToplamTutar.Size = new System.Drawing.Size(120, 22);
            this.numToplamTutar.TabIndex = 3;
            // 
            // btnOdaEkle
            // 
            this.btnOdaEkle.Location = new System.Drawing.Point(312, 166);
            this.btnOdaEkle.Name = "btnOdaEkle";
            this.btnOdaEkle.Size = new System.Drawing.Size(103, 23);
            this.btnOdaEkle.TabIndex = 4;
            this.btnOdaEkle.Text = "Oda Ekle";
            this.btnOdaEkle.UseVisualStyleBackColor = true;
            this.btnOdaEkle.Click += new System.EventHandler(this.btnOdaEkle_Click);
            // 
            // btnOdaSil
            // 
            this.btnOdaSil.Location = new System.Drawing.Point(984, 334);
            this.btnOdaSil.Name = "btnOdaSil";
            this.btnOdaSil.Size = new System.Drawing.Size(159, 41);
            this.btnOdaSil.TabIndex = 5;
            this.btnOdaSil.Text = "Oda Sil";
            this.btnOdaSil.UseVisualStyleBackColor = true;
            this.btnOdaSil.Click += new System.EventHandler(this.btnOdaSil_Click);
            // 
            // btnOdaTemizlik
            // 
            this.btnOdaTemizlik.Location = new System.Drawing.Point(984, 417);
            this.btnOdaTemizlik.Name = "btnOdaTemizlik";
            this.btnOdaTemizlik.Size = new System.Drawing.Size(159, 46);
            this.btnOdaTemizlik.TabIndex = 6;
            this.btnOdaTemizlik.Text = "Temizlik Durumunu Değiştir";
            this.btnOdaTemizlik.UseVisualStyleBackColor = true;
            this.btnOdaTemizlik.Click += new System.EventHandler(this.btnodaTemizlik_Click);
            // 
            // lblOdaİslemleri
            // 
            this.lblOdaİslemleri.AutoSize = true;
            this.lblOdaİslemleri.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOdaİslemleri.Location = new System.Drawing.Point(494, 25);
            this.lblOdaİslemleri.Name = "lblOdaİslemleri";
            this.lblOdaİslemleri.Size = new System.Drawing.Size(181, 32);
            this.lblOdaİslemleri.TabIndex = 7;
            this.lblOdaİslemleri.Text = "Oda İşlemleri";
            this.lblOdaİslemleri.Click += new System.EventHandler(this.lblOdaİslemleri_Click);
            // 
            // btnMusaitlikDolulukDurumuu
            // 
            this.btnMusaitlikDolulukDurumuu.Location = new System.Drawing.Point(984, 502);
            this.btnMusaitlikDolulukDurumuu.Name = "btnMusaitlikDolulukDurumuu";
            this.btnMusaitlikDolulukDurumuu.Size = new System.Drawing.Size(159, 43);
            this.btnMusaitlikDolulukDurumuu.TabIndex = 8;
            this.btnMusaitlikDolulukDurumuu.Text = "Doluluk Durumunu Düzenle";
            this.btnMusaitlikDolulukDurumuu.UseVisualStyleBackColor = true;
            // 
            // lblOdaNumarasi
            // 
            this.lblOdaNumarasi.AutoSize = true;
            this.lblOdaNumarasi.Location = new System.Drawing.Point(52, 111);
            this.lblOdaNumarasi.Name = "lblOdaNumarasi";
            this.lblOdaNumarasi.Size = new System.Drawing.Size(94, 16);
            this.lblOdaNumarasi.TabIndex = 9;
            this.lblOdaNumarasi.Text = "Oda Numarası";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Oda Tipi";
            // 
            // txtOdaTipi
            // 
            this.txtOdaTipi.Location = new System.Drawing.Point(164, 167);
            this.txtOdaTipi.Name = "txtOdaTipi";
            this.txtOdaTipi.Size = new System.Drawing.Size(100, 22);
            this.txtOdaTipi.TabIndex = 11;
            // 
            // txtToplamTutar
            // 
            this.txtToplamTutar.Location = new System.Drawing.Point(164, 228);
            this.txtToplamTutar.Name = "txtToplamTutar";
            this.txtToplamTutar.Size = new System.Drawing.Size(100, 22);
            this.txtToplamTutar.TabIndex = 12;
            // 
            // lblOdaFiyati
            // 
            this.lblOdaFiyati.AutoSize = true;
            this.lblOdaFiyati.Location = new System.Drawing.Point(52, 234);
            this.lblOdaFiyati.Name = "lblOdaFiyati";
            this.lblOdaFiyati.Size = new System.Drawing.Size(68, 16);
            this.lblOdaFiyati.TabIndex = 13;
            this.lblOdaFiyati.Text = "Oda Fiyatı";
            // 
            // OdaDetayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 664);
            this.Controls.Add(this.lblOdaFiyati);
            this.Controls.Add(this.txtToplamTutar);
            this.Controls.Add(this.txtOdaTipi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblOdaNumarasi);
            this.Controls.Add(this.txtOdaNumarasi);
            this.Controls.Add(this.dgvOdaListesi);
            this.Controls.Add(this.btnMusaitlikDolulukDurumuu);
            this.Controls.Add(this.btnOdaTemizlik);
            this.Controls.Add(this.btnOdaSil);
            this.Controls.Add(this.btnOdaEkle);
            this.Controls.Add(this.lblOdaİslemleri);
            this.Name = "OdaDetayForm";
            this.Text = "Oda Yönetimi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdaListesi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numToplamTutar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOdaListesi;
        private System.Windows.Forms.TextBox txtOdaNumarasi;
        private System.Windows.Forms.NumericUpDown numToplamTutar;
        private System.Windows.Forms.Button btnOdaEkle;
        private System.Windows.Forms.Button btnOdaSil;
        private System.Windows.Forms.Button btnOdaTemizlik;
        private System.Windows.Forms.Label lblOdaİslemleri;
        private System.Windows.Forms.Button btnMusaitlikDolulukDurumuu;
        private System.Windows.Forms.Label lblOdaNumarasi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOdaTipi;
        private System.Windows.Forms.TextBox txtToplamTutar;
        private System.Windows.Forms.Label lblOdaFiyati;
    }
}