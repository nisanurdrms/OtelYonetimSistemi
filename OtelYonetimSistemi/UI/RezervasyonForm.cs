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

namespace OtelYonetimSistemi.UI
{
    public partial class RezervasyonForm : Form
    {
        public RezervasyonForm()
        {
            InitializeComponent();
            LoadRoomTypes();
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
            // Seçilen oda tipine göre oda numaralarını yükle
            string selectedRoomType = cmbOdaTipi.SelectedItem.ToString();
            LoadRoomNumbers(selectedRoomType);
        }

        private void LoadRoomNumbers(string roomType)
        {
            try
            {
                cmbOdaNumarasi.Items.Clear(); // Önceki listeyi temizle

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
                                cmbOdaNumarasi.Items.Add(reader["odaNumarasi"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oda numaraları yüklenirken hata oluştu: " + ex.Message);
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

                // Seçilen oda tipine göre fiyatı belirle
                string selectedRoomType = cmbOdaTipi.SelectedItem.ToString();
                decimal roomPrice = GetRoomPriceByType(selectedRoomType); // Fiyatı al

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
            // Oda tipine göre sabit fiyatlar (örnek)
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

            DateTime checkInDate = dtpGirisTarihi.Value;
            DateTime checkOutDate = dtpCikisTarihi.Value;


            string odaTipi = cmbOdaTipi.SelectedItem?.ToString() ?? "Belirtilmedi";
            string adSoyad = txtAdSoyad.Text;
            string telNumarasi = txtTelNumarasi.Text;


            if (checkOutDate <= checkInDate)
            {
                MessageBox.Show("Çıkış tarihi giriş tarihinden sonra olmalıdır.");
                return;
            }

            using (MySqlConnection connection = dbBaglanti.BaglantiGetir())
            {
                MySqlTransaction transaction = connection.BeginTransaction(); // İşlem başlat
                try
                {
                    // 1. Müşteri Tablosuna Veri Ekle
                    string customerQuery = "INSERT INTO musteri (adSoyad, telNumarasi, odaNumarasi, girisTarihi, cikisTarihi, faturaDurumu) " +
                                           "VALUES (@Name, @Phone, @RoomNumber, @CheckInDate, @CheckOutDate, 'Bekliyor')";
                    MySqlCommand customerCommand = new MySqlCommand(customerQuery, connection, transaction);
                    customerCommand.Parameters.AddWithValue("@Name", adSoyad);
                    customerCommand.Parameters.AddWithValue("@Phone", telNumarasi);
                    customerCommand.Parameters.AddWithValue("@RoomNumber", odaNumarasi);
                    customerCommand.Parameters.AddWithValue("@CheckInDate", checkInDate);
                    customerCommand.Parameters.AddWithValue("@CheckOutDate", checkOutDate);
                    customerCommand.ExecuteNonQuery();

                    int customerId = (int)customerCommand.LastInsertedId; // Eklenen müşteri ID'sini al

                    // 2. Rezervasyon Tablosuna Veri Ekle
                    string reservationQuery = "INSERT INTO rezervasyon (musteriID, odaID, faturaID, girisTarihi, cikisTarihi, rezervasyonDurumu, toplamTutar) " +
                                              "VALUES (@CustomerID, @RoomID, NULL, @CheckInDate, @CheckOutDate, 'Bekliyor', @TotalAmount)";
                    MySqlCommand reservationCommand = new MySqlCommand(reservationQuery, connection, transaction);
                    reservationCommand.Parameters.AddWithValue("@CustomerID", customerId);
                    reservationCommand.Parameters.AddWithValue("@RoomID", odaNumarasi);
                    reservationCommand.Parameters.AddWithValue("@CheckInDate", checkInDate);
                    reservationCommand.Parameters.AddWithValue("@CheckOutDate", checkOutDate);
                    reservationCommand.Parameters.AddWithValue("@TotalAmount", toplamTutar);
                    reservationCommand.ExecuteNonQuery();

                    int reservationId = (int)reservationCommand.LastInsertedId; // Eklenen rezervasyon ID'sini al

                    // 3. Oda Tablosunu Güncelle
                    string roomUpdateQuery = "UPDATE oda SET dolulukDurumu = 'Dolu' WHERE odaNumarasi = @RoomNumber";
                    MySqlCommand roomUpdateCommand = new MySqlCommand(roomUpdateQuery, connection, transaction);
                    roomUpdateCommand.Parameters.AddWithValue("@RoomNumber", odaNumarasi);
                    roomUpdateCommand.ExecuteNonQuery();

                    // 4. Fatura Tablosuna Veri Ekle
                    string invoiceQuery = "INSERT INTO fatura (rezervasyonID, toplamTutar, odenmeDurumu, olusturulmaTarihi) " +
                                          "VALUES (@ReservationID, @TotalAmount, 'Bekliyor', NOW())";
                    MySqlCommand invoiceCommand = new MySqlCommand(invoiceQuery, connection, transaction);
                    invoiceCommand.Parameters.AddWithValue("@ReservationID", reservationId);
                    invoiceCommand.Parameters.AddWithValue("@TotalAmount", toplamTutar);
                    invoiceCommand.ExecuteNonQuery();

                    // İşlemi tamamla
                    transaction.Commit();
                    MessageBox.Show("Rezervasyon ve fatura başarıyla kaydedildi.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Hata durumunda işlemi geri al
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }


        }

        private void txtAdSoyad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}