using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtelYonetimSistemi.DAL;
using OtelYonetimSistemi.DOMAIN;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace OtelYonetimSistemi.SERVICE
{
    public class RezervasyonService
    {
        private readonly RezervasyonDAO rezervasyonDAO;
        private readonly OdaDAO odaDAO;

        public RezervasyonService()
        {
            rezervasyonDAO = new RezervasyonDAO();
            odaDAO = new OdaDAO();
        }

        public bool RezervasyonOlustur(Rezervasyon rezervasyon)
        {
            
            if (rezervasyon.GirisTarihi >= rezervasyon.CikisTarihi)
                throw new Exception("Giriş tarihi, çıkış tarihinden önce olmalıdır!");

            
            Oda oda = odaDAO.OdaGetir(rezervasyon.OdaID);
            if (oda == null || oda.DolulukDurumu)
                throw new Exception("Seçilen oda müsait değil!");

           
            int gunSayisi = (rezervasyon.CikisTarihi - rezervasyon.GirisTarihi).Days;
            decimal gunlukToplamTutar = oda.OdaTipi == "Suit" ? 1000 : 500; 
            rezervasyon.ToplamTutar = gunlukToplamTutar * gunSayisi;

            
            bool sonuc = rezervasyonDAO.RezervasyonEkle(rezervasyon);
            if (sonuc)
            {
                
                oda.DolulukDurumu = true;
                odaDAO.OdaGuncelle(oda);
            }

            return sonuc;
        }

        public bool RezervasyonIptal(int rezervasyonID)
        {
            Rezervasyon rezervasyon = rezervasyonDAO.RezervasyonGetir(rezervasyonID);
            if (rezervasyon == null)
                throw new Exception("Rezervasyon bulunamadı!");

            rezervasyon.RezervasyonDolulukDurumuu = "İptal";

            
            Oda oda = odaDAO.OdaGetir(rezervasyon.OdaID);
            oda.DolulukDurumu = false;
            odaDAO.OdaGuncelle(oda);

            return true;
        }

        public List<Rezervasyon> TumRezervasyonlariGetir()
        {
            List<Rezervasyon> rezervasyonlar = new List<Rezervasyon>();
            
            try
            {
                using (MySqlConnection conn = dbBaglanti.BaglantiGetir())
                {
                    string query = @"SELECT r.rezervasyonID, r.odaID, r.girisTarihi, r.cikisTarihi, 
                                   r.toplamTutar, m.adSoyad, m.telNumarasi, o.odaNumarasi 
                                   FROM rezervasyon r 
                                   JOIN musteri m ON r.musteriID = m.musteriID 
                                   JOIN oda o ON r.odaID = o.odaID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rezervasyonlar.Add(new Rezervasyon
                            {
                                RezervasyonID = Convert.ToInt32(reader["rezervasyonID"]),
                                OdaID = Convert.ToInt32(reader["odaID"]),
                                GirisTarihi = Convert.ToDateTime(reader["girisTarihi"]),
                                CikisTarihi = Convert.ToDateTime(reader["cikisTarihi"]),
                                ToplamTutar = Convert.ToDecimal(reader["toplamTutar"]),
                                MusteriAdSoyad = reader["adSoyad"].ToString(),
                                MusteriTelefon = reader["telNumarasi"].ToString(),
                                OdaNumarasi = reader["odaNumarasi"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyonlar getirilirken hata oluştu: " + ex.Message);
            }

            return rezervasyonlar;
        }
    }
}
