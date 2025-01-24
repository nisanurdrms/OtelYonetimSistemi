using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OtelYonetimSistemi.DAL;

namespace OtelYonetimSistemi.UI
{
    public partial class MusteriForm : Form
    {
        private readonly MusteriDAO musteriDAO;

        public MusteriForm()
        {
            InitializeComponent();
            musteriDAO = new MusteriDAO();
            MusterileriYukle();
        }

        public void PopulateRoomNumbers()
        {
            string connectionString = "Server=172.21.54.253;Database=25_132330003;User=25_132330003;Password=Deneme123!;"; // Bağlantı dizginizi buraya yazın.
            string query = "SELECT odaNumarasi FROM oda";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    cmbOdaNumarasi.Items.Clear();
                    while (reader.Read())
                    {
                        cmbOdaNumarasi.Items.Add(reader["odaNumarasi"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void MusterileriYukle()
        {
            try
            {
                using (MySqlConnection conn = dbBaglanti.BaglantiGetir())
                {
                    string query = "SELECT musteriID as 'Müşteri ID', adSoyad as 'Ad Soyad', " +
                                 "telNumarasi as 'Telefon' FROM musteri ORDER BY adSoyad";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvMusteri.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteriler yüklenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void dgvMusteriler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMusteri.SelectedRows.Count > 0)
            {
                txtAdSoyad.Text = dgvMusteri.SelectedRows[0].Cells["Ad Soyad"].Value.ToString();
                txtTelNumarasi.Text = dgvMusteri.SelectedRows[0].Cells["Telefon"].Value.ToString();
            }
        }

        private void FormuTemizle()
        {
            txtAdSoyad.Clear();
            txtTelNumarasi.Clear();
            txtAdSoyad.Focus();
        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAdSoyad.Text) ||
                    string.IsNullOrWhiteSpace(txtTelNumarasi.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlConnection conn = dbBaglanti.BaglantiGetir())
                {
                    string query = "INSERT INTO musteri (adSoyad, telNumarasi) VALUES (@ad, @tel)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ad", txtAdSoyad.Text);
                        cmd.Parameters.AddWithValue("@tel", txtTelNumarasi.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Müşteri başarıyla eklendi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormuTemizle();
                MusterileriYukle(); // Tabloyu yenile
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri eklenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (dgvMusteri.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen güncellenecek müşteriyi seçin!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int musteriID = Convert.ToInt32(dgvMusteri.SelectedRows[0].Cells["Müşteri ID"].Value);

                using (MySqlConnection conn = dbBaglanti.BaglantiGetir())
                {
                    string query = "UPDATE musteri SET adSoyad = @ad, telNumarasi = @tel " +
                                 "WHERE musteriID = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ad", txtAdSoyad.Text);
                        cmd.Parameters.AddWithValue("@tel", txtTelNumarasi.Text);
                        cmd.Parameters.AddWithValue("@id", musteriID);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Müşteri başarıyla güncellendi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormuTemizle();
                MusterileriYukle(); // Tabloyu yenile
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri güncellenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMusteri.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen silinecek müşteriyi seçin!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Seçili müşteriyi silmek istediğinize emin misiniz?",
                    "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int musteriID = Convert.ToInt32(dgvMusteri.SelectedRows[0].Cells["Müşteri ID"].Value);

                    using (MySqlConnection conn = dbBaglanti.BaglantiGetir())
                    {
                        // Önce müşterinin rezervasyonu var mı kontrol et
                        string checkQuery = "SELECT COUNT(*) FROM rezervasyon WHERE musteriID = @id";
                        using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@id", musteriID);
                            int rezervasyonSayisi = Convert.ToInt32(checkCmd.ExecuteScalar());

                            if (rezervasyonSayisi > 0)
                            {
                                MessageBox.Show("Bu müşteriye ait rezervasyon(lar) bulunmaktadır. " +
                                    "Önce rezervasyonları silmelisiniz.", "Uyarı",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        // Rezervasyon yoksa müşteriyi sil
                        string deleteQuery = "DELETE FROM musteri WHERE musteriID = @id";
                        using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                        {
                            deleteCmd.Parameters.AddWithValue("@id", musteriID);
                            deleteCmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Müşteri başarıyla silindi.", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormuTemizle();
                    MusterileriYukle(); // Tabloyu yenile
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri silinirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTelNumarasi_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbOdaNumarasi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
    
}
