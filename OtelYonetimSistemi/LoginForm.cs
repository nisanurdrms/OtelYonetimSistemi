using System;
using System.Windows.Forms;
using OtelYonetimSistemi.DAL;
using OtelYonetimSistemi.SERVICE;
using MySql.Data.MySqlClient;


namespace OtelYonetimSistemi
{
    public partial class LoginForm : Form
    {
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection baglanti = dbBaglanti.BaglantiGetir())
                {
                    baglanti.Open();
                    MessageBox.Show("Veritabanı bağlantısı başarılı!", "Bağlantı Testi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            txtadminName.Focus();
        }


        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtadminName.Text))
            {
                MessageBox.Show("Kullanıcı adı boş olamaz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtadminName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtadminSifre.Text))
            {
                MessageBox.Show("Şifre boş olamaz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtadminSifre.Focus();
                return;
            }

            else
            {

                try
                {
                    YoneticiService yoneticiService = new YoneticiService();
                    if (yoneticiService.GirisKontrol(txtadminName.Text, txtadminSifre.Text))
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
                        txtadminSifre.Clear();
                        txtadminSifre.Focus();
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

}

