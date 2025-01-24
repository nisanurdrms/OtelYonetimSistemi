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
            public MusteriForm()
            {
                InitializeComponent();
                LoadCustomers(); // Form açıldığında müşteri bilgilerini yükle
            }

            // Müşteri bilgilerini DataGridView'e yükleme
            private void LoadCustomers()
            {
                try
                {
                    using (MySqlConnection connection = dbBaglanti.BaglantiGetir())
                    {
                        string query = "SELECT musteriID, adSoyad, telNumarasi, odaNumarasi, girisTarihi, cikisTarihi, faturaDurumu FROM musteri";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            dgvMusteri.Rows.Clear(); // Önceki verileri temizle
                            while (reader.Read())
                            {
                                dgvMusteri.Rows.Add(reader["musteriID"].ToString(),
                                    reader["adSoyad"].ToString(),
                                    reader["telNumarasi"].ToString(),
                                    reader["odaNumarasi"].ToString(),
                                    Convert.ToDateTime(reader["girisTarihi"]).ToString("yyyy-MM-dd"),
                                    Convert.ToDateTime(reader["cikisTarihi"]).ToString("yyyy-MM-dd"),
                                    reader["faturaDurumu"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Müşteriler yüklenirken hata oluştu: " + ex.Message);
                }
            }

            // Yeni müşteri ekleme
            private void btnMusteriEkle_Click(object sender, EventArgs e)
            {
                try
                {
                    using (MySqlConnection connection = dbBaglanti.BaglantiGetir())
                    {
                        string query = "INSERT INTO musteri (adSoyad, telNumarasi, odaNumarasi, girisTarihi, cikisTarihi, faturaDurumu) " +
                                       "VALUES (@AdSoyad, @TelNumarasi, @OdaNumarasi, @GirisTarihi, @CikisTarihi, 'Bekliyor')";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@AdSoyad", txtAdSoyad.Text);
                            command.Parameters.AddWithValue("@TelNumarasi", txtTelNumarasi.Text);
                            command.Parameters.AddWithValue("@OdaNumarasi", cmbOdaNumarasi.SelectedItem?.ToString());
                            command.Parameters.AddWithValue("@GirisTarihi", dtpGirisTarihi.Value);
                            command.Parameters.AddWithValue("@CikisTarihi", dtpCikisTarihi.Value);

                            command.ExecuteNonQuery();
                        }
                    }

                    LoadCustomers(); // Yeni müşteri ekledikten sonra listeyi güncelle
                    MessageBox.Show("Müşteri başarıyla eklendi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }

            

            

        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {
            try
            {
                int musteriID = Convert.ToInt32(dgvMusteri.CurrentRow.Cells["musteriID"].Value);
                string query = "UPDATE musteri SET adSoyad = @AdSoyad, telNumarasi = @TelNumarasi, odaNumarasi = @OdaNumarasi, girisTarihi = @GirisTarihi, cikisTarihi = @CikisTarihi WHERE musteriID = @MusteriID";

                using (MySqlConnection connection = dbBaglanti.BaglantiGetir())
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MusteriID", musteriID);
                    command.Parameters.AddWithValue("@AdSoyad", txtAdSoyad.Text);
                    command.Parameters.AddWithValue("@TelNumarasi", txtTelNumarasi.Text);
                    command.Parameters.AddWithValue("@OdaNumarasi", cmbOdaNumarasi.SelectedItem?.ToString());
                    command.Parameters.AddWithValue("@GirisTarihi", dtpGirisTarihi.Value);
                    command.Parameters.AddWithValue("@CikisTarihi", dtpCikisTarihi.Value);

                    command.ExecuteNonQuery();
                }

                LoadCustomers(); // Listeyi güncelle
                MessageBox.Show("Müşteri başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            try
            {
                int musteriID = Convert.ToInt32(dgvMusteri.CurrentRow.Cells["musteriID"].Value);
                string query = "DELETE FROM musteri WHERE musteriID = @MusteriID";

                using (MySqlConnection connection = dbBaglanti.BaglantiGetir())
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MusteriID", musteriID);
                    command.ExecuteNonQuery();
                }

                LoadCustomers(); // Listeyi güncelle
                MessageBox.Show("Müşteri başarıyla silindi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}
