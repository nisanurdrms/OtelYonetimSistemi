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
        private MusteriForm musteriForm;
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
            try
            {
                RezervasyonDAO rezervasyonDAO = new RezervasyonDAO();
                var rezervasyonlar = rezervasyonDAO.RezervasyonGetir();

                dgvRezervasyonlar.DataSource = rezervasyonlar; // DataGridView'e bağla
                dgvRezervasyonlar.Columns["OdaID"].Visible = false; // Gerekli olmayan kolonları gizle
                dgvRezervasyonlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyonlar yüklenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void OdalariYukle()
        {
            try
            {
                flpOdalar.Controls.Clear(); // FlowLayoutPanel içeriğini temizle
                OdaService odaService = new OdaService();
                var odalar = odaService.TumOdalariGetir(); // Tüm odaları getir

                foreach (Oda oda in odalar)
                {
                    // Oda için buton oluştur
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
                                    Color.FromArgb(76, 175, 80)), // Dolu, temizlik durumlarına göre renk
                        ForeColor = oda.DolulukDurumu || !oda.OdaTemizlik ? Color.White : Color.Black
                    };

                    flpOdalar.Controls.Add(btnOda); // FlowLayoutPanel'e butonu ekle


                    private void menuCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Programdan çıkmak istediğinizden emin misiniz?",
           "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        
        private void menuOdaYonetimi_Click(object sender, EventArgs e)
        {
            if (odaDetayForm == null || odaDetayForm.IsDisposed) 
            {
                string connectionString = "Server=172.21.54.253;Database=25_132330003;User=25_132330003;Password=Deneme123!;"; 
                OdaDetayForm odaDetayForm = new OdaDetayForm(connectionString);
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

        private void menuMusteriYonetimi_Click(object sender, EventArgs e)
        {
            if (musteriForm == null || musteriForm.IsDisposed)
            {
               
                musteriForm = new MusteriForm();
                musteriForm.Show();

            }
            else
            {
                musteriForm.BringToFront();
            }
        }

    }
}
