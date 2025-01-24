using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using OtelYonetimSistemi.DAL;
using OtelYonetimSistemi.DOMAIN;
using OtelYonetimSistemi.SERVICE;

namespace OtelYonetimSistemi.UI
{
    public partial class RezervasyonForm : Form
    {
        private OdaDetayForm odaDetayForm;
        public RezervasyonForm()
        {
            InitializeComponent();
            this.odaDetayForm = odaDetayForm;
            LoadRoomTypes();

        }

        private void RezervasyonForm_Load(object sender, EventArgs e)
        {
            PopulateRoomTypes();
        }

        private void PopulateRoomTypes()
        {
            string connectionString = "Server=172.21.54.253;Database=25_132330003;User=25_132330003;Password=Deneme123!;";// Veritabanı bağlantı dizesini buraya yaz.
            string query = "SELECT DISTINCT odaTipi FROM oda";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    cmbOdaTipi.Items.Clear();
                    while (reader.Read())
                    {
                        cmbOdaTipi.Items.Add(reader["odaTipi"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        public void PopulateRoomNumbers()
        {
            string connectionString = "Server=172.21.54.253;Database=25_132330003;User=25_132330003;Password=Deneme123!;"; // Bağlantı dizginizi buraya yazın.
            string query = "SELECT odaNumarasi FROM oda";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    cmbOdaNumarasi.Items.Clear();
                    while (reader.Read())
                    {
                        cmbOdaNumarasi.Items.Add(reader["odaNumarasi"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }


        private void LoadRoomTypes()
        {
            try
            {
                using (MySqlConnection connection = dbBaglanti.BaglantiGetir())
                {
                    string query = "SELECT DISTINCT odaTipi FROM oda";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbOdaTipi.Items.Add(reader["odaTipi"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oda tipleri yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void cmbOdaTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRoomType = cmbOdaTipi.SelectedItem.ToString();
            PopulateRoomNumbers(selectedRoomType);
        }

        private void PopulateRoomNumbers(string roomType)
        {
            string connectionString = "your_connection_string_here"; // Veritabanı bağlantı dizesini buraya ekle.
            string query = "SELECT RoomNumber FROM Rooms WHERE RoomType = @RoomType";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@RoomType", roomType);
                    MySqlDataReader reader = command.ExecuteReader();

                    cmbOdaNumarasi.Items.Clear();
                    while (reader.Read())
                    {
                        cmbOdaNumarasi.Items.Add(reader["RoomNumber"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }



        private void LoadRoomNumbers(string roomType)
        {
            try
            {
                cmbOdaNumarasi.Items.Clear(); // Clear the existing room numbers

                using (MySqlConnection connection = dbBaglanti.BaglantiGetir())
                {
                    string query = "SELECT odaNumarasi FROM oda WHERE odaTipi = @RoomType AND dolulukDurumu = 'Boş'";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoomType", roomType);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string roomNumber = reader["odaNumarasi"].ToString();
                                cmbOdaNumarasi.Items.Add(roomNumber);

                                // Debug line to print room numbers in the console
                                Console.WriteLine("Room Number Loaded: " + roomNumber); // Debug line
                            }
                        }
                    }
                }

                if (cmbOdaNumarasi.Items.Count == 0)
                {
                    MessageBox.Show("No available rooms found for this room type.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading room numbers: " + ex.Message);
            }
        }



        private void cmbOdaNumarasi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRoomNumber = cmbOdaNumarasi.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedRoomNumber))
            {
                // You can add logic here if you want to show room details, etc.
                // For example, display the room number or disable/enable other buttons
                MessageBox.Show($"Oda numarası {selectedRoomNumber} seçildi.");

                // Optionally, enable the reservation button if a room is selected
                btnRezervasyonYap.Enabled = true;
            }
            else
            {
                // Disable the reservation button if no room is selected
                btnRezervasyonYap.Enabled = false;
            }
        }


        private void CalculateTotalAmount()
        {
            try
            {
                if (cmbOdaTipi.SelectedItem == null || dtpGirisTarihi.Value == null || dtpCikisTarihi.Value == null)
                {
                    lblToplamTutar.Text = "Lütfen tüm bilgileri girin.";
                    return;
                }

                // Tarih farkını hesapla
                DateTime checkInDate = dtpGirisTarihi.Value.Date;
                DateTime checkOutDate = dtpCikisTarihi.Value.Date;
                int dayDifference = (checkOutDate - checkInDate).Days;

                if (dayDifference <= 0)
                {
                    lblToplamTutar.Text = "Geçerli bir tarih aralığı girin.";
                    return;
                }

                // Seçilen oda tipine göre ToplamTutarı belirle
                string selectedRoomType = cmbOdaTipi.SelectedItem.ToString();
                decimal roomPrice = GetRoomPriceByType(selectedRoomType); // ToplamTutarı al

                // Toplam tutarı hesapla
                decimal totalAmount = dayDifference * roomPrice;

                // Toplam tutarı göster
                lblToplamTutar.Text = $"Toplam Tutar: {totalAmount:C}"; // ₺ sembolü otomatik gelir
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private decimal GetRoomPriceByType(string roomType)
        {
            // Oda tipine göre sabit ToplamTutarlar (örnek)
            if (roomType == "Standart")
                return 500m; // 500₺
            else if (roomType == "Deluxe")
                return 750m; // 750₺
            else if (roomType == "Suit")
                return 1000m; // 1000₺
            else
                return 0m; // Tanımsız oda tipi
        }
        private void btnRezervasyonYap_Click(object sender, EventArgs e)
        {
            try
            {
                // Girişleri kontrol et
                if (string.IsNullOrEmpty(txtAdSoyad.Text) || string.IsNullOrEmpty(txtTelNumarasi.Text) ||
                    cmbOdaNumarasi.SelectedItem == null || cmbOdaTipi.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Müşteriyi ekle ve ID'sini al
                using (MySqlConnection conn = dbBaglanti.BaglantiGetir())
                {
                    string musteriQuery = @"INSERT INTO musteri (adSoyad, telNumarasi) 
                                          VALUES (@adSoyad, @telNo); 
                                          SELECT LAST_INSERT_ID();";
                    
                    using (MySqlCommand cmd = new MySqlCommand(musteriQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@adSoyad", txtAdSoyad.Text);
                        cmd.Parameters.AddWithValue("@telNo", txtTelNumarasi.Text);
                        int musteriID = Convert.ToInt32(cmd.ExecuteScalar());

                        // Rezervasyon nesnesini oluştur
                        var rezervasyon = new Rezervasyon
                        {
                            OdaID = GetRoomIDByRoomNumber(cmbOdaNumarasi.SelectedItem.ToString()),
                            MusteriID = musteriID,
                            GirisTarihi = dtpGirisTarihi.Value,
                            CikisTarihi = dtpCikisTarihi.Value,
                            ToplamTutar = Convert.ToDecimal(lblToplamTutar.Text.Replace("₺", "").Trim())
                        };

                        // Rezervasyonu ekle
                        RezervasyonService rezervasyonService = new RezervasyonService();
                        bool sonuc = rezervasyonService.RezervasyonEkle(rezervasyon);

                        if (sonuc)
                        {
                            MessageBox.Show("Rezervasyon başarıyla oluşturuldu!", "Başarılı",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Rezervasyon oluşturulurken bir hata oluştu!", "Hata",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyon işlemi sırasında bir hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private int GetRoomIDByRoomNumber(string roomNumber)
        {
            try
            {
                using (MySqlConnection connection = dbBaglanti.BaglantiGetir())
                {
                    string query = "SELECT odaID FROM oda WHERE odaNumarasi = @RoomNumber";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoomNumber", roomNumber);

                        object result = command.ExecuteScalar(); // Tek bir değer döneceği için ExecuteScalar kullanılır
                        if (result != null)
                        {
                            return Convert.ToInt32(result); // Oda ID'sini döndür
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oda ID alınırken hata oluştu: " + ex.Message);
            }

            return 0; // Hata DolulukDurumuunda veya oda bulunamazsa 0 döner
        }

        private void txtAdSoyad_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
                