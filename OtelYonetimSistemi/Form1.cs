using System;
using System.Windows.Forms;
using OtelYonetimSistemi.DAL;
using MySql.Data.MySqlClient;


namespace OtelYonetimSistemi
{
    public partial class Form1 : Form
    {
        private dbBaglanti db = new dbBaglanti(); 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection baglanti = db.BaglantiGetir(); 
                MessageBox.Show("Bağlantı başarılı!");
                baglanti.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı hatası: " + ex.Message);
            }
        }
    }
}

