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
using OtelYonetimSistemi.DAL;
using MySql;
using MySql.Data.MySqlClient;

namespace OtelYonetimSistemi
{
    public partial class MainForm : Form
    {
        private OdaDetayForm odaDetayForm;
        private RezervasyonForm rezervasyonForm;
        private MusteriForm musteriForm;
        private DolulukRaporu dolulukRaporu;
        private Timer timer;

       
        public MainForm()
        {
            InitializeComponent();
            {
                this.Text = "Otel Yönetim Sistemi";
                this.WindowState = FormWindowState.Maximized;
                this.StartPosition = FormStartPosition.CenterScreen;
                CustomizeDataGridView();
                LoadGeneralData();
                timer = new Timer();
                timer.Interval = 1000; // 1 saniyede bir çalışacak
                timer.Tick += Timer_Tick; // Her tetiklemede Timer_Tick metodu çalışacak
                timer.Start(); // Timer'ı başlat
            }

            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // StatusLabel üzerine tarih ve saat yaz
            statusLabelDateTime.Text = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss");
        }

        private void LoadGeneralData()
        {
            string connectionString = "Server=172.21.54.253;Database=25_132330003;User=25_132330003;Password=Deneme123!;";
            string query = "SELECT rezervasyonID, musteriID, odaID, faturaID, girisTarihi, cikisTarihi, rezervasyonDurumu, toplamTutar FROM rezervasyon";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);
                    dgvGenel.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void LoadRooms()
        {
            string connectionString = "Server=172.21.54.253;Database=25_132330003;User=25_132330003;Password=Deneme123!;"; 
            string query = "SELECT * FROM oda"; 

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dgvOda.DataSource = dataTable; 
            }
        }

        private void CustomizeDataGridView()
        {
            dgvGenel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGenel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGenel.AllowUserToAddRows = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //OdalariYukle();
            RezervasyonlariYukle();
            LoadRooms();
            
        }

       private void RezervasyonlariYukle()
        {
            try
            {
                RezervasyonDAO rezervasyonDAO = new RezervasyonDAO();
                var rezervasyonlar = rezervasyonDAO.RezervasyonGetir();

                dgvGenel.DataSource = rezervasyonlar; 
                dgvGenel.Columns["OdaID"].Visible = false; 
                dgvGenel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyonlar yüklenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

       /* private void OdalariYukle()
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Odalar yüklenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        private void menuCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Programdan çıkmak istediğinizden emin misiniz?",
           "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        
        public void menuOdaYonetimi_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = dbBaglanti.BaglantiGetir())
                {
                    if (connection != null)
                    {
                        OdaDetayForm odaDetayForm = new OdaDetayForm();
                        odaDetayForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Veritabanına bağlanılamadı!", "Bağlantı Hatası",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Form açılırken hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvGenel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnOdaYenile_Click(object sender, EventArgs e)
        {
            LoadRooms();
        }

        private void btnRezervasyon_Click(object sender, EventArgs e)
        {
            LoadGeneralData();
        }

        private void menuDolulukRaporu_Click(object sender, EventArgs e)
        {
            if (dolulukRaporu == null || dolulukRaporu.IsDisposed)
            {

                dolulukRaporu = new DolulukRaporu();
                dolulukRaporu.Show();

            }
            else
            {
                dolulukRaporu.BringToFront();
            }
        }
    }
}
