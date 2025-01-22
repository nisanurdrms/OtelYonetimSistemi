using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OtelYonetimSistemi.SERVICE;
using OtelYonetimSistemi.DOMAIN;
using OtelYonetimSistemi.UI;

namespace OtelYonetimSistemi
{
    public partial class MainForm : Form
    {
        private OdaDetayForm odaDetayForm;
        private RezervasyonForm rezervasyonForm;
        public MainForm()
        {
            InitializeComponent();
            {
                this.Text = "Otel Yönetim Sistemi";
                this.WindowState = FormWindowState.Maximized;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OdalariYukle();
            RezervasyonlariYukle();
            lblStatus.Text = $"Son güncelleme: {DateTime.Now:dd.MM.yyyy HH:mm:ss}";
        }

        private void RezervasyonlariYukle()
        {
            throw new NotImplementedException();
        }

        private void OdalariYukle()
        {
            try
            {
                flpOdalar.Controls.Clear();
                OdaService odaService = new OdaService();
                var odalar = odaService.TumOdalariGetir();

                foreach (Oda oda in odalar)
                {
                    Button btnOda = new Button
                    {
                        Text = $"Oda {oda.OdaNumarasi}\n{oda.OdaTipi}",
                        Tag = oda,
                        Width = 120,
                        Height = 80,
                        Margin = new Padding(5),
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Segoe UI", 9, FontStyle.Bold),
                        BackColor = oda.DolulukDurumu ? Color.FromArgb(244, 67, 54) : 
                               (!oda.OdaTemizlik ? Color.FromArgb(255, 235, 59) : 
                               Color.FromArgb(76, 175, 80)), 
                        ForeColor = oda.DolulukDurumu || !oda.OdaTemizlik ? Color.White : Color.Black
                    };
                    btnOda.FlatAppearance.BorderSize = 0;
                    btnOda.Click += new EventHandler(btnOda_Click);
                    flpOdalar.Controls.Add(btnOda);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Odalar yüklenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Programdan çıkmak istediğinizden emin misiniz?",
           "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnOda_Click(object sender, EventArgs e)
        {

        }

        private void lblOdaDurum_Click(object sender, EventArgs e)
        {

        }

        private void lblAktifRezervasyon_Click(object sender, EventArgs e)
        {

        }

        private void menuOdaYonetimi_Click(object sender, EventArgs e)
        {
            if (odaDetayForm == null || odaDetayForm.IsDisposed) 
            {
                odaDetayForm = new OdaDetayForm(); 
                odaDetayForm.Show();        
            }
            else
            {
                odaDetayForm.BringToFront(); 
            }
        }

        private void menuRezervasyonYonetimi_Click(object sender, EventArgs e)
        {
            if (rezervasyonForm == null || rezervasyonForm.IsDisposed)
            {
                rezervasyonForm = new RezervasyonForm();
                rezervasyonForm.Show();
            }
            else
            {
                rezervasyonForm.BringToFront();
            }
        }
    }
}
