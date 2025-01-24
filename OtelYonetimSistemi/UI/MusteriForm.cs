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
            OdaNumaralariniYukle(); // ComboBox için
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
                    string query = @"SELECT 
                                   musteriID as 'Müşteri ID',
                                   adSoyad as 'Ad Soyad',
                                   telNumarasi as 'Telefon',
                                   odaNumarasi as 'Oda No',
                                   DATE_FORMAT(girisTarihi, '%d.%m.%Y') as 'Giriş Tarihi',
                                   DATE_FORMAT(cikisTarihi, '%d.%m.%Y') as 'Çıkış Tarihi',
                                   CASE 
                                       WHEN faturaDurumu = 1 THEN 'Ödendi'
                                       ELSE 'Ödenmedi'
                                   END as 'Fatura Durumu'
                                   FROM musteri 
                                   ORDER BY adSoyad";

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

        private void OdaNumaralariniYukle()
        {
            try
            {
                using (MySqlConnection conn = dbBaglanti.BaglantiGetir())
                {
                    string query = "SELECT odaNumarasi FROM oda WHERE dolulukDurumu = 0 ORDER BY odaNumarasi";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            cmbOdaNumarasi.Items.Clear();
                            while (reader.Read())
                            {
                                cmbOdaNumarasi.Items.Add(reader["odaNumarasi"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oda numaraları yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                // Veri kontrolü
                if (string.IsNullOrWhiteSpace(txtAdSoyad.Text) || 
                    string.IsNullOrWhiteSpace(txtTelNumarasi.Text) ||
                    cmbOdaNumarasi.SelectedItem == null ||
                    dtpGirisTarihi.Value > dtpCikisTarihi.Value)  // Tarih kontrolü ekledik
                {
                    MessageBox.Show("Lütfen tüm alanları doğru şekilde doldurun!\n" +
                        "- Ad Soyad boş olamaz\n" +
                        "- Telefon boş olamaz\n" +
                        "- Oda numarası seçilmeli\n" +
                        "- Giriş tarihi çıkış tarihinden büyük olamaz",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlConnection conn = dbBaglanti.BaglantiGetir())
                {
                    // Transaction başlat
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Müşteri ekle
                            string musteriQuery = @"INSERT INTO musteri 
                                           (adSoyad, telNumarasi, odaNumarasi, girisTarihi, cikisTarihi, faturaDurumu)
                                           VALUES 
                                           (@ad, @tel, @odaNo, @giris, @cikis, @fatura)";

                            using (MySqlCommand cmd = new MySqlCommand(musteriQuery, conn))
                            {
                                cmd.Transaction = transaction;
                                cmd.Parameters.AddWithValue("@ad", txtAdSoyad.Text.Trim());
                                cmd.Parameters.AddWithValue("@tel", txtTelNumarasi.Text.Trim());
                                cmd.Parameters.AddWithValue("@odaNo", cmbOdaNumarasi.SelectedItem.ToString());
                                cmd.Parameters.AddWithValue("@giris", dtpGirisTarihi.Value.Date);
                                cmd.Parameters.AddWithValue("@cikis", dtpCikisTarihi.Value.Date);
                                cmd.Parameters.AddWithValue("@fatura", false);

                                int affectedRows = cmd.ExecuteNonQuery();
                                
                                if (affectedRows <= 0)
                                {
                                    throw new Exception("Müşteri kaydı eklenemedi!");
                                }
                            }

                            // Odayı dolu olarak işaretle
                            string odaQuery = "UPDATE oda SET dolulukDurumu = 1 WHERE odaNumarasi = @odaNo";
                            using (MySqlCommand odaCmd = new MySqlCommand(odaQuery, conn))
                            {
                                odaCmd.Transaction = transaction;
                                odaCmd.Parameters.AddWithValue("@odaNo", cmbOdaNumarasi.SelectedItem.ToString());
                                
                                int affectedRows = odaCmd.ExecuteNonQuery();
                                
                                if (affectedRows <= 0)
                                {
                                    throw new Exception("Oda durumu güncellenemedi!");
                                }
                            }

                            // İşlemleri onayla
                            transaction.Commit();

                            MessageBox.Show("Müşteri başarıyla eklendi.", "Bilgi",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            FormuTemizle();
                            MusterileriYukle();
                            OdaNumaralariniYukle();
                        }
                        catch (Exception ex)
                        {
                            // Hata durumunda işlemleri geri al
                            transaction.Rollback();
                            throw new Exception("İşlem sırasında hata oluştu: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri eklenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
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
                    string query = @"UPDATE musteri 
                                   SET adSoyad = @ad, 
                                       telNumarasi = @tel,
                                       odaNumarasi = @odaNo,
                                       girisTarihi = @giris,
                                       cikisTarihi = @cikis,
                                       faturaDurumu = @fatura
                                   WHERE musteriID = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ad", txtAdSoyad.Text);
                        cmd.Parameters.AddWithValue("@tel", txtTelNumarasi.Text);
                        cmd.Parameters.AddWithValue("@odaNo", cmbOdaNumarasi.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@giris", dtpGirisTarihi.Value);
                        cmd.Parameters.AddWithValue("@cikis", dtpCikisTarihi.Value);
                        cmd.Parameters.AddWithValue("@fatura", chkFaturaOdendi.Checked);
                        cmd.Parameters.AddWithValue("@id", musteriID);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Müşteri başarıyla güncellendi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                FormuTemizle();
                MusterileriYukle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri güncellenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMusteri_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMusteri.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvMusteri.SelectedRows[0];
                txtAdSoyad.Text = row.Cells["Ad Soyad"].Value.ToString();
                txtTelNumarasi.Text = row.Cells["Telefon"].Value.ToString();
                cmbOdaNumarasi.Text = row.Cells["Oda No"].Value.ToString();
                dtpGirisTarihi.Value = Convert.ToDateTime(row.Cells["Giriş Tarihi"].Value);
                dtpCikisTarihi.Value = Convert.ToDateTime(row.Cells["Çıkış Tarihi"].Value);
                chkFaturaOdendi.Checked = row.Cells["Fatura Durumu"].Value.ToString() == "Ödendi";
            }
        }

        private void FormuTemizle()
        {
            txtAdSoyad.Clear();
            txtTelNumarasi.Clear();
            cmbOdaNumarasi.SelectedIndex = -1;
            dtpGirisTarihi.Value = DateTime.Now;
            dtpCikisTarihi.Value = DateTime.Now.AddDays(1);
            chkFaturaOdendi.Checked = false;
            txtAdSoyad.Focus();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            
                txtAdSoyad.Clear();
                txtTelNumarasi.Clear();
                cmbOdaNumarasi.SelectedIndex = -1;
                dtpGirisTarihi.Value = DateTime.Now;
                dtpCikisTarihi.Value = DateTime.Now.AddDays(1);
                chkFaturaOdendi.Checked = false;
                txtAdSoyad.Focus();
            
        }

        
    }
}
