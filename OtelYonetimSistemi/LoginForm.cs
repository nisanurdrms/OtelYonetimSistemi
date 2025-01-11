using System;
using System.Windows.Forms;
using OtelYonetimSistemi.DAL;
using MySql.Data.MySqlClient;


namespace OtelYonetimSistemi
{
    public partial class LoginForm : Form
    {
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection baglanti = dbBaglanti.BaglantiGetir();  
                MessageBox.Show("Bağlantı başarılı!");
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı hatası: " + ex.Message);
            }
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {

        }
    }

}

