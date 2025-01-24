using MySql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace OtelYonetimSistemi.DAL
{
    public static class dbBaglanti
    {
        private static readonly string connectionString = "Server=172.21.54.253;Database=25_132330003;User=25_132330003;Password=Deneme123!;";
                                                        

        public static MySqlConnection BaglantiGetir()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                return connection;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message);
                return null;
            }
        }
    }
}

