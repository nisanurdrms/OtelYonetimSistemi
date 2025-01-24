using System;
using System.Data;
using System.Windows.Forms;
using OtelYonetimSistemi.DAL;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace OtelYonetimSistemi.UI
{
    public partial class OdaDetayForm : Form
    {
        private string _connectionString;

        // Constructor to accept the connection string
        public OdaDetayForm(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString; // Store the connection string
            DataGridViewiAyarla(); // Set up the DataGridView
            LoadRooms(); // Load rooms from the database
        }

        public OdaDetayForm()  // Constructor'ı parametresiz yap
        {
            InitializeComponent();
            LoadRooms();
        }

        // Set up the DataGridView columns
        private void DataGridViewiAyarla()
        {
            dgvOdaListesi.AutoGenerateColumns = false;
            dgvOdaListesi.Columns.Clear();

            dgvOdaListesi.Columns.AddRange(
                new DataGridViewTextBoxColumn
                {
                    Name = "OdaID",
                    DataPropertyName = "odaID",
                    HeaderText = "Oda ID",
                    Width = 80,
                    DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "OdaNumarasi",
                    DataPropertyName = "odaNumarasi",
                    HeaderText = "Oda Numarası",
                    Width = 100,
                    DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "OdaTipi",
                    DataPropertyName = "odaTipi",
                    HeaderText = "Oda Tipi",
                    Width = 100,
                    DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "DolulukDurumu",
                    DataPropertyName = "dolulukDurumu",
                    HeaderText = "Doluluk Durumu",
                    Width = 100,
                    DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "OdaTemizlik",
                    DataPropertyName = "odaTemizlik",
                    HeaderText = "Temizlik Durumu",
                    Width = 100,
                    DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "OdaodaFiyat",
                    DataPropertyName = "odaFiyat",
                    HeaderText = "Oda Fiyati",
                    Width = 100,
                    DefaultCellStyle =
                    {
                        Alignment = DataGridViewContentAlignment.MiddleRight,
                        Format = "C2"
                    }
                }
            );
        }

        // Load rooms from the database and display them in the DataGridView
        private void LoadRooms()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open(); // Ensure the connection is open
                    string query = @"SELECT odaID, odaNumarasi, odaTipi, 
                                       dolulukDurumu, odaTemizlik, odaFiyat 
                                       FROM oda ORDER BY odaNumarasi";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvOdaListesi.DataSource = dt; // Bind the data to the grid
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Odalar yüklenirken hata oluştu: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add a new room
        private void btnOdaEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtOdaNumarasi.Text) ||
                    string.IsNullOrWhiteSpace(txtOdaTipi.Text) ||
                    string.IsNullOrWhiteSpace(txtToplamTutar.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO oda (odaNumarasi, odaTipi, dolulukDurumu, 
                                   odaTemizlik, odaFiyat) 
                                   VALUES (@odaNo, @tip, 'Boş', 'Temiz', @odaFiyat)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@odaNo", txtOdaNumarasi.Text);
                    cmd.Parameters.AddWithValue("@tip", txtOdaTipi.Text);
                    cmd.Parameters.AddWithValue("@odaFiyat", Convert.ToDecimal(txtToplamTutar.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Oda başarıyla eklendi.", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtOdaNumarasi.Clear();
                    txtOdaTipi.Clear();
                    txtToplamTutar.Clear();
                    LoadRooms(); // Refresh the grid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oda eklenirken hata oluştu: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Delete a selected room
        private void btnOdaSil_Click(object sender, EventArgs e)
        {
            if (dgvOdaListesi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek odayı seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Seçili odayı silmek istediğinize emin misiniz?", "Onay",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int odaID = Convert.ToInt32(dgvOdaListesi.SelectedRows[0].Cells["OdaID"].Value);
                    using (MySqlConnection conn = new MySqlConnection(_connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM oda WHERE odaID = @odaID";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@odaID", odaID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Oda başarıyla silindi.", "Bilgi",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRooms(); // Refresh the grid
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Oda silinirken hata oluştu: " + ex.Message, "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Update the cleaning status of a selected room
        private void btnodaTemizlik_Click(object sender, EventArgs e)
        {
            if (dgvOdaListesi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir oda seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int odaID = Convert.ToInt32(dgvOdaListesi.SelectedRows[0].Cells["OdaID"].Value);
                string mevcutDurum = dgvOdaListesi.SelectedRows[0].Cells["odaTemizlik"].Value.ToString();
                string yeniDurum = mevcutDurum == "Temiz" ? "Kirli" : "Temiz";

                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "UPDATE oda SET odaTemizlik = @durum WHERE odaID = @odaID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@durum", yeniDurum);
                    cmd.Parameters.AddWithValue("@odaID", odaID);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Temizlik durumu güncellendi.", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRooms(); // Refresh the grid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Temizlik durumu güncellenirken hata oluştu: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblOdaİslemleri_Click(object sender, EventArgs e)
        {

        }
    }
}
