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
            
            // Form yüklenirken yapılacak işlemler
            this.Load += MusteriForm_Load;
            
            // DataGridView ayarları
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            dgvMusteri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMusteri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMusteri.MultiSelect = false;
            dgvMusteri.ReadOnly = true;
            dgvMusteri.AllowUserToAddRows = false;
            dgvMusteri.AllowUserToDeleteRows = false;
            dgvMusteri.AllowUserToOrderColumns = true;
        }

        private void MusteriForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Form yüklenirken kontrolleri ayarla
                dtpGirisTarihi.MinDate = DateTime.Now;
                dtpCikisTarihi.MinDate = DateTime.Now.AddDays(1);
                
                // Telefon formatı için mask
                txtTelNumarasi.MaxLength = 11;
                
                // ComboBox için varsayılan seçim
                cmbOdaNumarasi.DropDownStyle = ComboBoxStyle.DropDownList;
                
                // Verileri yükle
                MusterileriYukle();
                OdaNumaralariniYukle();
                
                // Form temizle
                FormuTemizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form yüklenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpGirisTarihi_ValueChanged(object sender, EventArgs e)
        {
            // Giriş tarihi değiştiğinde çıkış tarihini güncelle
            dtpCikisTarihi.MinDate = dtpGirisTarihi.Value.AddDays(1);
            if (dtpCikisTarihi.Value <= dtpGirisTarihi.Value)
            {
                dtpCikisTarihi.Value = dtpGirisTarihi.Value.AddDays(1);
            }
        }

        private void txtTelNumarasi_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece rakam ve kontrol tuşlarına izin ver
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            FormuTemizle();
        }

        private void FormuTemizle()
        {
            txtAdSoyad.Clear();
            txtTelNumarasi.Clear();
            cmbOdaNumarasi.SelectedIndex = -1;
            dtpGirisTarihi.Value = DateTime.Now;
            dtpCikisTarihi.Value = DateTime.Now.AddDays(1);
            chkFaturaOdendi.Checked = false;
            
            // Seçili satırı temizle
            if (dgvMusteri.SelectedRows.Count > 0)
            {
                dgvMusteri.ClearSelection();
            }
            
            txtAdSoyad.Focus();
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

                    // Kolon genişliklerini ayarla
                    dgvMusteri.Columns["Müşteri ID"].Width = 80;
                    dgvMusteri.Columns["Ad Soyad"].Width = 150;
                    dgvMusteri.Columns["Telefon"].Width = 100;
                    dgvMusteri.Columns["Oda No"].Width = 80;
                    dgvMusteri.Columns["Giriş Tarihi"].Width = 100;
                    dgvMusteri.Columns["Çıkış Tarihi"].Width = 100;
                    dgvMusteri.Columns["Fatura Durumu"].Width = 100;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteriler yüklenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMusteri_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Fatura durumuna göre renklendirme
            if (dgvMusteri.Columns[e.ColumnIndex].Name == "Fatura Durumu")
            {
                if (e.Value != null)
                {
                    if (e.Value.ToString() == "Ödendi")
                    {
                        e.CellStyle.ForeColor = Color.Green;
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void txtAdSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece harf ve kontrol tuşlarına izin ver
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
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
                if (string.IsNullOrWhiteSpace(txtAdSoyad.Text))
                {
                    MessageBox.Show("Lütfen müşteri adını giriniz!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAdSoyad.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTelNumarasi.Text))
                {
                    MessageBox.Show("Lütfen telefon numarasını giriniz!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelNumarasi.Focus();
                    return;
                }

                if (cmbOdaNumarasi.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen bir oda seçiniz!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbOdaNumarasi.Focus();
                    return;
                }

                using (MySqlConnection conn = dbBaglanti.BaglantiGetir())
                {
                    // Transaction başlat
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string query = @"INSERT INTO musteri 
                                           (adSoyad, telNumarasi, odaNumarasi, girisTarihi, cikisTarihi, faturaDurumu) 
                                           VALUES 
                                           (@adSoyad, @telNo, @odaNo, @giris, @cikis, @fatura)";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Transaction = transaction;
                                cmd.Parameters.AddWithValue("@adSoyad", txtAdSoyad.Text.Trim());
                                cmd.Parameters.AddWithValue("@telNo", txtTelNumarasi.Text.Trim());
                                cmd.Parameters.AddWithValue("@odaNo", cmbOdaNumarasi.SelectedItem.ToString());
                                cmd.Parameters.AddWithValue("@giris", dtpGirisTarihi.Value.Date);
                                cmd.Parameters.AddWithValue("@cikis", dtpCikisTarihi.Value.Date);
                                cmd.Parameters.AddWithValue("@fatura", chkFaturaOdendi.Checked);

                                cmd.ExecuteNonQuery();
                            }

                            // Odayı dolu olarak işaretle
                            string updateQuery = "UPDATE oda SET dolulukDurumu = 1 WHERE odaNumarasi = @odaNo";
                            using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                            {
                                updateCmd.Transaction = transaction;
                                updateCmd.Parameters.AddWithValue("@odaNo", cmbOdaNumarasi.SelectedItem.ToString());
                                updateCmd.ExecuteNonQuery();
                            }

                            // İşlemi onayla
                            transaction.Commit();

                            MessageBox.Show("Müşteri başarıyla eklendi!", "Bilgi", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Formu temizle ve verileri yenile
                            FormuTemizle();
                            MusterileriYukle();
                            OdaNumaralariniYukle();
                        }
                        catch (Exception ex)
                        {
                            // Hata durumunda işlemi geri al
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
                        cmd.Parameters.AddWithValue("@ad", txtAdSoyad.Text.Trim());
                        cmd.Parameters.AddWithValue("@tel", txtTelNumarasi.Text.Trim());
                        cmd.Parameters.AddWithValue("@odaNo", cmbOdaNumarasi.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@giris", dtpGirisTarihi.Value.Date);
                        cmd.Parameters.AddWithValue("@cikis", dtpCikisTarihi.Value.Date);
                        cmd.Parameters.AddWithValue("@fatura", chkFaturaOdendi.Checked);
                        cmd.Parameters.AddWithValue("@id", musteriID);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Müşteri bilgileri başarıyla güncellendi!", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                MusterileriYukle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMusteri_SelectionChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Seçili müşteri bilgileri yüklenirken hata oluştu: " + ex.Message,
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

                if (MessageBox.Show("Seçili müşteriyi silmek istediğinize emin misiniz?", "Onay",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int musteriID = Convert.ToInt32(dgvMusteri.SelectedRows[0].Cells["Müşteri ID"].Value);
                    string odaNo = dgvMusteri.SelectedRows[0].Cells["Oda No"].Value.ToString();

                    using (MySqlConnection conn = dbBaglanti.BaglantiGetir())
                    {
                        using (MySqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                // Müşteriyi sil
                                string deleteQuery = "DELETE FROM musteri WHERE musteriID = @id";
                                using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                                {
                                    deleteCmd.Transaction = transaction;
                                    deleteCmd.Parameters.AddWithValue("@id", musteriID);
                                    deleteCmd.ExecuteNonQuery();
                                }

                                // Odayı boş olarak işaretle
                                string updateQuery = "UPDATE oda SET dolulukDurumu = 0 WHERE odaNumarasi = @odaNo";
                                using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                                {
                                    updateCmd.Transaction = transaction;
                                    updateCmd.Parameters.AddWithValue("@odaNo", odaNo);
                                    updateCmd.ExecuteNonQuery();
                                }

                                transaction.Commit();

                                MessageBox.Show("Müşteri başarıyla silindi!", "Bilgi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                FormuTemizle();
                                MusterileriYukle();
                                OdaNumaralariniYukle();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                throw new Exception("İşlem sırasında hata oluştu: " + ex.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri silinirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
