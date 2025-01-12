using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OtelYonetimSistemi.DAL
{
    public class YoneticiDAO
    {
        private readonly string connectionString = "Server=172.21.54.253;Database=25_132330003;User=25_132330003;Password=Deneme123!";

        public (string adminName, string adminSifre) KullaniciGetir(string adminName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT adminName, adminSifre FROM Yoneticiler WHERE adminName = @adminName";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@adminName", adminName);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (reader["adminName"].ToString(), reader["adminSifre"].ToString());
                        }
                    }
                }
            }

            return default; 
        }
    }
}

