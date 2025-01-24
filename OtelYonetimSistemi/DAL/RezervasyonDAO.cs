using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using OtelYonetimSistemi.DOMAIN;

namespace OtelYonetimSistemi.DAL
{
    public class RezervasyonDAO
    {
        public bool RezervasyonEkle(Rezervasyon rezervasyon)
        {
            using (MySqlConnection conn = dbBaglanti.BaglantiGetir())
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO rezervasyon (musteriID, odaID, girisTarihi, cikisTarihi, " +
                               "rezervasyonDolulukDurumuu, toplamTutar) VALUES (@musteriID, @odaID, @girisTarihi, " +
                               "@cikisTarihi, @rezervasyonDolulukDurumuu, @toplamTutar)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@musteriID", rezervasyon.MusteriID);
                    cmd.Parameters.AddWithValue("@odaID", rezervasyon.OdaID);
                    cmd.Parameters.AddWithValue("@girisTarihi", rezervasyon.GirisTarihi);
                    cmd.Parameters.AddWithValue("@cikisTarihi", rezervasyon.CikisTarihi);
                    cmd.Parameters.AddWithValue("@rezervasyonDolulukDurumuu", rezervasyon.RezervasyonDolulukDurumuu);
                    cmd.Parameters.AddWithValue("@toplamTutar", rezervasyon.ToplamTutar);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Rezervasyon eklenirken hata oluştu: " + ex.Message);
                }
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
                                RezervasyonDolulukDurumuu = reader.GetString("rezervasyonDolulukDurumuu"),
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
    }
}
