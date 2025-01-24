using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace OtelYonetimSistemi.SERVICE
{
    public class YoneticiService
    {
        private readonly string connectionString = "Server=172.21.54.253;Database=25_132330003;Username=25_132330003;Password=Deneme123!;";

        public bool GirisKontrol(string adminName, string adminSifre)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "SELECT COUNT(*) FROM Yonetici WHERE adminName = @adminName AND adminSifre = @adminSifre";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@adminName", adminName);
                        command.Parameters.AddWithValue("@adminSifre", adminSifre);
                        
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Veritabanı bağlantı hatası: {ex.Message}", "Hata");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Beklenmeyen hata: {ex.Message}", "Hata");
                return false;
            }
        }

        public void TestDatabaseContent()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Bağlantı başarılı!", "Test");

                    var query = "SELECT * FROM Yonetici";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("Yonetici tablosunda hiç kayıt yok!", "Uyarı");
                                return;
                            }

                            StringBuilder results = new StringBuilder();
                            while (reader.Read())
                            {
                                string admin = reader["adminName"].ToString();
                                string sifre = reader["adminSifre"].ToString();
                                results.AppendLine($"Admin: {admin}, Şifre: {sifre}");
                            }
                            MessageBox.Show(results.ToString(), "Veritabanı Kayıtları");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Test hatası: {ex.Message}", "Hata");
            }
        }
    }
}

