﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtelYonetimSistemi.DAL;
using OtelYonetimSistemi.DOMAIN;

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
            if (oda == null || oda.DolulukDolulukDurumuu)
                throw new Exception("Seçilen oda müsait değil!");

           
            int gunSayisi = (rezervasyon.CikisTarihi - rezervasyon.GirisTarihi).Days;
            decimal gunlukToplamTutar = oda.OdaTipi == "Suit" ? 1000 : 500; 
            rezervasyon.ToplamTutar = gunlukToplamTutar * gunSayisi;

            
            bool sonuc = rezervasyonDAO.RezervasyonEkle(rezervasyon);
            if (sonuc)
            {
                
                oda.DolulukDolulukDurumuu = true;
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
            oda.DolulukDolulukDurumuu = false;
            odaDAO.OdaGuncelle(oda);

            return true;
        }
    }
}
