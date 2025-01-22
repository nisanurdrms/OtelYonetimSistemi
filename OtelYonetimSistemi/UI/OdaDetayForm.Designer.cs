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
            this.lblOdaİslemleri = new System.Windows.Forms.Label();
            this.btnOdaEkle = new System.Windows.Forms.Button();
            this.btnOdaSil = new System.Windows.Forms.Button();
            this.btnTemizlikDurumu = new System.Windows.Forms.Button();
            this.btnMusaitlikDurumu = new System.Windows.Forms.Button();
            this.dgvOdaListesi = new System.Windows.Forms.DataGridView();
            this.txtOdaNumarasi = new System.Windows.Forms.TextBox();
            this.cmbOdaTipi = new System.Windows.Forms.ComboBox();
            this.lblOdaNumarasi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdaListesi)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOdaİslemleri
            // 
            this.lblOdaİslemleri.AutoSize = true;
            this.lblOdaİslemleri.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOdaİslemleri.Location = new System.Drawing.Point(466, 40);
            this.lblOdaİslemleri.Name = "lblOdaİslemleri";
            this.lblOdaİslemleri.Size = new System.Drawing.Size(181, 32);
            this.lblOdaİslemleri.TabIndex = 0;
            this.lblOdaİslemleri.Text = "Oda İşlemleri";
            // 
            // btnOdaEkle
            // 
            this.btnOdaEkle.Location = new System.Drawing.Point(165, 326);
            this.btnOdaEkle.Name = "btnOdaEkle";
            this.btnOdaEkle.Size = new System.Drawing.Size(75, 23);
            this.btnOdaEkle.TabIndex = 1;
            this.btnOdaEkle.Text = "Oda Ekle";
            this.btnOdaEkle.UseVisualStyleBackColor = true;
            // 
            // btnOdaSil
            // 
            this.btnOdaSil.Location = new System.Drawing.Point(801, 199);
            this.btnOdaSil.Name = "btnOdaSil";
            this.btnOdaSil.Size = new System.Drawing.Size(159, 41);
            this.btnOdaSil.TabIndex = 2;
            this.btnOdaSil.Text = "Oda Sil";
            this.btnOdaSil.UseVisualStyleBackColor = true;
            // 
            // btnTemizlikDurumu
            // 
            this.btnTemizlikDurumu.Location = new System.Drawing.Point(801, 282);
            this.btnTemizlikDurumu.Name = "btnTemizlikDurumu";
            this.btnTemizlikDurumu.Size = new System.Drawing.Size(159, 46);
            this.btnTemizlikDurumu.TabIndex = 3;
            this.btnTemizlikDurumu.Text = "Temizlik Durumunu Güncelle";
            this.btnTemizlikDurumu.UseVisualStyleBackColor = true;
            // 
            // btnMusaitlikDurumu
            // 
            this.btnMusaitlikDurumu.Location = new System.Drawing.Point(801, 367);
            this.btnMusaitlikDurumu.Name = "btnMusaitlikDurumu";
            this.btnMusaitlikDurumu.Size = new System.Drawing.Size(159, 43);
            this.btnMusaitlikDurumu.TabIndex = 4;
            this.btnMusaitlikDurumu.Text = "Müsaitlik Durumunu Otomatikleştir";
            this.btnMusaitlikDurumu.UseVisualStyleBackColor = true;
            // 
            // dgvOdaListesi
            // 
            this.dgvOdaListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOdaListesi.Location = new System.Drawing.Point(389, 122);
            this.dgvOdaListesi.Name = "dgvOdaListesi";
            this.dgvOdaListesi.RowHeadersWidth = 51;
            this.dgvOdaListesi.RowTemplate.Height = 24;
            this.dgvOdaListesi.Size = new System.Drawing.Size(339, 414);
            this.dgvOdaListesi.TabIndex = 5;
            // 
            // txtOdaNumarasi
            // 
            this.txtOdaNumarasi.Location = new System.Drawing.Point(165, 203);
            this.txtOdaNumarasi.Name = "txtOdaNumarasi";
            this.txtOdaNumarasi.Size = new System.Drawing.Size(100, 22);
            this.txtOdaNumarasi.TabIndex = 6;
            // 
            // cmbOdaTipi
            // 
            this.cmbOdaTipi.FormattingEnabled = true;
            this.cmbOdaTipi.Items.AddRange(new object[] {
            "Standart",
            "Deluxe",
            "Suit"});
            this.cmbOdaTipi.Location = new System.Drawing.Point(165, 257);
            this.cmbOdaTipi.Name = "cmbOdaTipi";
            this.cmbOdaTipi.Size = new System.Drawing.Size(121, 24);
            this.cmbOdaTipi.TabIndex = 7;
            // 
            // lblOdaNumarasi
            // 
            this.lblOdaNumarasi.AutoSize = true;
            this.lblOdaNumarasi.Location = new System.Drawing.Point(53, 206);
            this.lblOdaNumarasi.Name = "lblOdaNumarasi";
            this.lblOdaNumarasi.Size = new System.Drawing.Size(94, 16);
            this.lblOdaNumarasi.TabIndex = 8;
            this.lblOdaNumarasi.Text = "Oda Numarası";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Oda Tipi";
            // 
            // OdaDetayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 765);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblOdaNumarasi);
            this.Controls.Add(this.cmbOdaTipi);
            this.Controls.Add(this.txtOdaNumarasi);
            this.Controls.Add(this.dgvOdaListesi);
            this.Controls.Add(this.btnMusaitlikDurumu);
            this.Controls.Add(this.btnTemizlikDurumu);
            this.Controls.Add(this.btnOdaSil);
            this.Controls.Add(this.btnOdaEkle);
            this.Controls.Add(this.lblOdaİslemleri);
            this.Name = "OdaDetayForm";
            this.Text = "OdaDetayForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdaListesi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOdaİslemleri;
        private System.Windows.Forms.Button btnOdaEkle;
        private System.Windows.Forms.Button btnOdaSil;
        private System.Windows.Forms.Button btnTemizlikDurumu;
        private System.Windows.Forms.Button btnMusaitlikDurumu;
        private System.Windows.Forms.DataGridView dgvOdaListesi;
        private System.Windows.Forms.TextBox txtOdaNumarasi;
        private System.Windows.Forms.ComboBox cmbOdaTipi;
        private System.Windows.Forms.Label lblOdaNumarasi;
        private System.Windows.Forms.Label label1;
    }
}