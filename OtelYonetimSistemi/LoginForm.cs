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

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
            txtKullaniciAdi.Focus();
        }

        
        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKullaniciAdi.Text))
            {
                MessageBox.Show("Kullanıcı adı boş olamaz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKullaniciAdi.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtSifre.Text))
            {
                MessageBox.Show("Şifre boş olamaz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSifre.Focus();
                return;
            }

            try
            {
                YoneticiService yoneticiService = new YoneticiService();
                if (yoneticiService.GirisKontrol(txtKullaniciAdi.Text, txtSifre.Text))
                {
                    MainForm mainForm = new MainForm();
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSifre.Clear();
                    txtSifre.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giriş işlemi sırasında hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}

