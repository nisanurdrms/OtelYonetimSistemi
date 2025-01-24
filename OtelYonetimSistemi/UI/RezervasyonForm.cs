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
                    string query = "SELECT odaNumarasi FROM oda WHERE odaTipi = @RoomType AND dolulukDolulukDurumuu = 'Boş'";
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
            // Tarih ve diğer alanları alın
            DateTime checkInDate = dtpGirisTarihi.Value;
            DateTime checkOutDate = dtpCikisTarihi.Value;

            // Kullanıcı girdilerini al
            string odaNumarasi = cmbOdaNumarasi.SelectedItem?.ToString(); // Seçilen oda numarasını al
            string odaTipi = cmbOdaTipi.SelectedItem?.ToString() ?? "Belirtilmedi";
            string adSoyad = txtAdSoyad.Text;
            string telNumarasi = txtTelNumarasi.Text;

            // Tarih doğrulaması yap
            if (checkOutDate <= checkInDate)
            {
                MessageBox.Show("Çıkış tarihi giriş tarihinden sonra olmalıdır.");
                return;
            }

            // Oda numarasının seçilmiş olup olmadığını kontrol et
            if (string.IsNullOrEmpty(odaNumarasi))
            {
                MessageBox.Show("Lütfen bir oda numarası seçin.");
                return;
            }

            // Oda ID'sini al
            int odaID = GetRoomIDByRoomNumber(odaNumarasi);
            if (odaID == 0)
            {
                MessageBox.Show("Seçilen oda numarasına ait oda bulunamadı.");
                return;
            }

            decimal toplamTutar = 0; // Varsayılan toplam tutar

            // Toplam tutar hesaplama (isteğe bağlı)
            CalculateTotalAmount();

            try
            {
                using (MySqlConnection connection = dbBaglanti.BaglantiGetir())
                {
                    MySqlTransaction transaction = connection.BeginTransaction(); // İşlem başlat
                    try
                    {
                        // 1. Müşteri Tablosuna Veri Ekle
                        string customerQuery = "INSERT INTO musteri (adSoyad, telNumarasi, odaNumarasi, girisTarihi, cikisTarihi, faturaDolulukDurumuu) " +
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
                        string reservationQuery = "INSERT INTO rezervasyon (musteriID, odaID, faturaID, girisTarihi, cikisTarihi, rezervasyonDolulukDurumuu, toplamTutar) " +
                                                  "VALUES (@CustomerID, @RoomID, NULL, @CheckInDate, @CheckOutDate, 'Bekliyor', @TotalAmount)";
                        MySqlCommand reservationCommand = new MySqlCommand(reservationQuery, connection, transaction);
                        reservationCommand.Parameters.AddWithValue("@CustomerID", customerId);
                        reservationCommand.Parameters.AddWithValue("@RoomID", odaID); // Oda ID'sini kullan
                        reservationCommand.Parameters.AddWithValue("@CheckInDate", checkInDate);
                        reservationCommand.Parameters.AddWithValue("@CheckOutDate", checkOutDate);
                        reservationCommand.Parameters.AddWithValue("@TotalAmount", toplamTutar);
                        reservationCommand.ExecuteNonQuery();

                        int reservationId = (int)reservationCommand.LastInsertedId; // Eklenen rezervasyon ID'sini al

                        // 3. Oda Tablosunu Güncelle
                        string roomUpdateQuery = "UPDATE oda SET dolulukDolulukDurumuu = 'Dolu' WHERE odaID = @RoomID";
                        MySqlCommand roomUpdateCommand = new MySqlCommand(roomUpdateQuery, connection, transaction);
                        roomUpdateCommand.Parameters.AddWithValue("@RoomID", odaID);
                        roomUpdateCommand.ExecuteNonQuery();

                        // 4. Fatura Tablosuna Veri Ekle
                        string invoiceQuery = "INSERT INTO fatura (rezervasyonID, toplamTutar, odenmeDolulukDurumuu, olusturulmaTarihi) " +
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
                        transaction.Rollback(); // Hata DolulukDurumuunda işlemi geri al
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
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
                