using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OtelYonetimSistemi.SERVICE
{
    public class YoneticiService
    {
        private readonly string connectionString = "Server=172.21.54.253;Database=25_132330003;User=25_132330003;Password=Deneme123!;";

        public bool GirisKontrol(string kullaniciAdi, string sifre)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT COUNT(*) FROM Yonetici WHERE adminName = @adminName AND adminSifre = @adminSifre";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@adminName", kullaniciAdi);
                    command.Parameters.AddWithValue("@adminSifre", sifre);

                    
                    int count = (int)command.ExecuteScalar();
                    return count > 0; 
                }
            }
        }
    }
}

