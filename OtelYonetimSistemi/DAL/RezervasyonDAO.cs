using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using OtelYonetimSistemi.DOMAIN;
using System.Data;
using System.Windows.Forms;

namespace OtelYonetimSistemi.DAL
{
    public class RezervasyonDAO
    {
        public DataTable RezervasyonGetir()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = dbBaglanti.BaglantiGetir())
                {
                    string query = @"SELECT 
                                   r.rezervasyonID as 'Rezervasyon No',
                                   m.adSoyad as 'Müşteri',
                                   m.telNumarasi as 'Telefon',
                                   o.odaNumarasi as 'Oda No',
                                   r.girisTarihi as 'Giriş Tarihi',
                                   r.cikisTarihi as 'Çıkış Tarihi',
                                   r.toplamTutar as 'Toplam Tutar',
                                   r.odaID as 'OdaID'
                                   FROM rezervasyon r
                                   JOIN musteri m ON r.musteriID = m.musteriID
                                   JOIN oda o ON r.odaID = o.odaID
                                   ORDER BY r.girisTarihi DESC";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyon bilgileri getirilirken hata oluştu: " + ex.Message,
                    "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public bool RezervasyonEkle(int odaID, int musteriID, DateTime girisTarihi, 
            DateTime cikisTarihi, decimal toplamTutar)
        {
            try
            {
                using (MySqlConnection conn = dbBaglanti.BaglantiGetir())
                {
                    string query = @"INSERT INTO rezervasyon 
                                   (odaID, musteriID, girisTarihi, cikisTarihi, toplamTutar)
                                   VALUES 
                                   (@odaID, @musteriID, @girisTarihi, @cikisTarihi, @toplamTutar)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@odaID", odaID);
                        cmd.Parameters.AddWithValue("@musteriID", musteriID);
                        cmd.Parameters.AddWithValue("@girisTarihi", girisTarihi);
                        cmd.Parameters.AddWithValue("@cikisTarihi", cikisTarihi);
                        cmd.Parameters.AddWithValue("@toplamTutar", toplamTutar);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyon eklenirken hata oluştu: " + ex.Message,
                    "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool RezervasyonSil(int rezervasyonID)
        {
            try
            {
                using (MySqlConnection conn = dbBaglanti.BaglantiGetir())
                {
                    string query = "DELETE FROM rezervasyon WHERE rezervasyonID = @rezervasyonID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@rezervasyonID", rezervasyonID);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyon silinirken hata oluştu: " + ex.Message,
                    "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public Rezervasyon RezervasyonGetir(int rezervasyonID)
        {
            using (MySqlConnection conn = dbBaglanti.BaglantiGetir())
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT r.*, m.adSoyad, o.odaNumarasi FROM rezervasyon r " +
                               "JOIN musteri m ON r.musteriID = m.musteriID " +
                               "JOIN oda o ON r.odaID = o.odaID " +
                               "WHERE r.rezervasyonID = @rezervasyonID";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@rezervasyonID", rezervasyonID);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Rezervasyon
                            {
                                RezervasyonID = reader.GetInt32("rezervasyonID"),
                                MusteriID = reader.GetInt32("musteriID"),
                                OdaID = reader.GetInt32("odaID"),
                                GirisTarihi = reader.GetDateTime("girisTarihi"),
                                CikisTarihi = reader.GetDateTime("cikisTarihi"),
                                ToplamTutar = reader.GetDecimal("toplamTutar"),
                                Musteri = new Musteri { AdSoyad = reader.GetString("adSoyad") },
                                Oda = new Oda { OdaNumarasi = reader.GetString("odaNumarasi") }
                            };
                        }
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Rezervasyon getirilirken hata oluştu: " + ex.Message);
                }
            }
        }

        internal static bool RezervasyonEkle(Rezervasyon rezervasyon)
        {
            throw new NotImplementedException();
        }
    }
}
