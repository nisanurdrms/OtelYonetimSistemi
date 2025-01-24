using System;
using System.Drawing;
using System.Windows.Forms;

namespace OtelYonetimSistemi.UI
{
    partial class DolulukRaporu
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
            this.progressBarDoluluk = new System.Windows.Forms.ProgressBar();
            this.lblDoluluk = new System.Windows.Forms.Label();
            this.prgBarDoluluk = new System.Windows.Forms.ProgressBar();
            this.lblDolulukDurumu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBarDoluluk
            // 
            this.progressBarDoluluk.Location = new System.Drawing.Point(226, 147);
            this.progressBarDoluluk.Name = "progressBarDoluluk";
            this.progressBarDoluluk.Size = new System.Drawing.Size(304, 87);
            this.progressBarDoluluk.TabIndex = 0;
            // 
            // lblDoluluk
            // 
            this.lblDoluluk.AutoSize = true;
            this.lblDoluluk.Location = new System.Drawing.Point(223, 94);
            this.lblDoluluk.Name = "lblDoluluk";
            this.lblDoluluk.Size = new System.Drawing.Size(87, 16);
            this.lblDoluluk.TabIndex = 1;
            this.lblDoluluk.Text = "Doluluk Oranı";
            // 
            // prgBarDoluluk
            // 
            this.prgBarDoluluk.Location = new System.Drawing.Point(245, 120);
            this.prgBarDoluluk.Name = "prgBarDoluluk";
            this.prgBarDoluluk.Size = new System.Drawing.Size(263, 73);
            this.prgBarDoluluk.TabIndex = 0;
            // 
            // lblDolulukDurumu
            // 
            this.lblDolulukDurumu.AutoSize = true;
            this.lblDolulukDurumu.Location = new System.Drawing.Point(242, 80);
            this.lblDolulukDurumu.Name = "lblDolulukDurumu";
            this.lblDolulukDurumu.Size = new System.Drawing.Size(44, 16);
            this.lblDolulukDurumu.TabIndex = 1;
            this.lblDolulukDurumu.Text = "label1";
            // 
            // DolulukRaporu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
   //         this.Controls.Add(this.lblDolulukDurumu);
   //         this.Controls.Add(this.prgBarDoluluk);
            this.Name = "DolulukRaporu";
            this.Text = "DolulukRaporu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void PerformLayout()
        {
            throw new NotImplementedException();
        }

        private void ResumeLayout(bool v)
        {
            throw new NotImplementedException();
        }

        private void SuspendLayout()
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarDoluluk;
        private System.Windows.Forms.Label lblDoluluk;
        private ProgressBar prgBarDoluluk;
        private Label lblDolulukDurumu;

        public string Name { get; private set; }
        public string Text { get; private set; }
        public object Controls { get; private set; }
        public AutoScaleMode AutoScaleMode { get; private set; }
        public Size ClientSize { get; private set; }
    }
}