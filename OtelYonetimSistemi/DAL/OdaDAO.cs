using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using OtelYonetimSistemi.DOMAIN;

namespace OtelYonetimSistemi.DAL
{
    public class OdaDAO
    {


        public bool OdaEkle(Oda oda)
        {
            using (MySqlConnection conn = dbBaglanti.BaglantiGetir())
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO oda (odaNumarasi, dolulukDurumu, odaTipi, odaTemizlik) " +
                               "VALUES (@odaNumarasi, @dolulukDurumu, @odaTipi, @odaTemizlik)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@odaNumarasi", oda.OdaNumarasi);
                    cmd.Parameters.AddWithValue("@dolulukDurumu", oda.DolulukDurumu);
                    cmd.Parameters.AddWithValue("@odaTipi", oda.OdaTipi);
                    cmd.Parameters.AddWithValue("@odaTemizlik", oda.OdaTemizlik);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Oda eklenirken hata oluştu: " + ex.Message);
                }
            }
        }

        public Oda OdaGetir(int odaID)
        {
            using (MySqlConnection conn = dbBaglanti.BaglantiGetir())
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM oda WHERE odaID = @odaID";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@odaID", odaID);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Oda
                            {
                                OdaID = reader.GetInt32("odaID"),
                                OdaNumarasi = reader.GetString("odaNumarasi"),
                                DolulukDurumu = reader.GetBoolean("dolulukDurumu"),
                                OdaTipi = reader.GetString("odaTipi"),
                                OdaTemizlik = reader.GetBoolean("odaTemizlik")
                            };
                        }
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Oda getirilirken hata oluştu: " + ex.Message);
                }
            }
        }

        public List<Oda> TumOdalariGetir()
        {
            List<Oda> odalar = new List<Oda>();
            using (MySqlConnection conn = dbBaglanti.BaglantiGetir())
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM oda";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            odalar.Add(new Oda
                            {
                                OdaID = reader.GetInt32("odaID"),
                                OdaNumarasi = reader.GetString("odaNumarasi"),
                                DolulukDurumu = reader.GetBoolean("dolulukDurumu"),
                                OdaTipi = reader.GetString("odaTipi"),
                                OdaTemizlik = reader.GetBoolean("odaTemizlik")
                            });
                        }
                    }
                    return odalar;
                }
                catch (Exception ex)
                {
                    throw new Exception("Odalar listelenirken hata oluştu: " + ex.Message);
                }
            }
        }

        public bool OdaGuncelle(Oda oda)
        {
            using (MySqlConnection conn = dbBaglanti.BaglantiGetir())
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE oda SET odaNumarasi = @odaNumarasi, dolulukDurumu = @dolulukDurumu, " +
                               "odaTipi = @odaTipi, odaTemizlik = @odaTemizlik WHERE odaID = @odaID";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@odaID", oda.OdaID);
                    cmd.Parameters.AddWithValue("@odaNumarasi", oda.OdaNumarasi);
                    cmd.Parameters.AddWithValue("@dolulukDurumu", oda.DolulukDurumu);
                    cmd.Parameters.AddWithValue("@odaTipi", oda.OdaTipi);
                    cmd.Parameters.AddWithValue("@odaTemizlik", oda.OdaTemizlik);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Oda güncellenirken hata oluştu: " + ex.Message);
                }
            }
        }

        public bool OdaSil(int odaID)
        {
            using (MySqlConnection conn = dbBaglanti.BaglantiGetir())
            {
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM oda WHERE odaID = @odaID";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@odaID", odaID);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Oda silinirken hata oluştu: " + ex.Message);
                }
            }
        }
    }
}
