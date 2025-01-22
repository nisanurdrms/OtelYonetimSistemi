using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using OtelYonetimSistemi.DAL;

namespace OtelYonetimSistemi.UI
{
    public partial class OdaDetayForm : Form
    {
        public OdaDetayForm()
        {
            InitializeComponent();
            OdaListele(); // Form yüklendiğinde odaları listele
        }

        // Odaları listeleme işlemi
        private void OdaListele()
        {
            try
            {
                using (MySqlConnection connection = dbBaglanti.BaglantiGetir())
                {
                    string query = "SELECT odaID, odaNumarasi, dolulukDurumu, odaTipi, odaTemizlik FROM oda";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvOdaListesi.DataSource = dt; // DataGridView'e veri bağla
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Odalar listelenirken hata oluştu: " + ex.Message);
            }
        }

        // Yeni oda ekleme işlemi
        private void btnOdaEkle_Click(object sender, EventArgs e)
        {
            string odaNumarasi = txtOdaNumarasi.Text;
            string odaTipi = cmbOdaTipi.SelectedItem?.ToString() ?? "Belirtilmedi";

            try
            {
                using (MySqlConnection connection = dbBaglanti.BaglantiGetir())
                {
                    string query = "INSERT INTO oda (odaNumarasi, dolulukDurumu, odaTipi, odaTemizlik) " +
                                   "VALUES (@OdaNumarasi, 'Müsait', @OdaTipi, 'Temiz')";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OdaNumarasi", odaNumarasi);
                        command.Parameters.AddWithValue("@OdaTipi", odaTipi);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Oda başarıyla eklendi.");
                        OdaListele(); // Listeyi güncelle
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oda eklenirken hata oluştu: " + ex.Message);
            }
        }

        // Oda silme işlemi
        private void btnOdaSil_Click(object sender, EventArgs e)
        {
            if (dgvOdaListesi.SelectedRows.Count > 0)
            {
                int odaID = Convert.ToInt32(dgvOdaListesi.SelectedRows[0].Cells["odaID"].Value);

                DialogResult result = MessageBox.Show("Bu odayı silmek istediğinize emin misiniz?",
                                                      "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection connection = dbBaglanti.BaglantiGetir())
                        {
                            string query = "DELETE FROM oda WHERE odaID = @OdaID";
                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@OdaID", odaID);
                                command.ExecuteNonQuery();
                                MessageBox.Show("Oda başarıyla silindi.");
                                OdaListele(); // Listeyi güncelle
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Oda silinirken hata oluştu: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz odayı seçin.");
            }
        }

        // Temizlik durumunu güncelleme işlemi
        private void btnTemizlikGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvOdaListesi.SelectedRows.Count > 0)
            {
                int odaID = Convert.ToInt32(dgvOdaListesi.SelectedRows[0].Cells["odaID"].Value);

                try
                {
                    using (MySqlConnection connection = dbBaglanti.BaglantiGetir())
                    {
                        string query = "UPDATE oda SET odaTemizlik = 'Temiz' WHERE odaID = @OdaID";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@OdaID", odaID);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Oda temizlik durumu güncellendi.");
                            OdaListele(); // Listeyi güncelle
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Temizlik durumu güncellenirken hata oluştu: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen temizlik durumunu güncellemek istediğiniz odayı seçin.");
            }
        }
    }
}
