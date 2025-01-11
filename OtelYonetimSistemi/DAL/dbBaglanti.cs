using MySql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelYonetimSistemi.DAL
{
    public static class dbBaglanti
    {
        public static MySqlConnection BaglantiGetir()
        {
           
            string connectionString = "Server=172.21.54.253;Database=25_132330003;User=25_132330003;Password=Deneme123!;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }
    }

    
}

