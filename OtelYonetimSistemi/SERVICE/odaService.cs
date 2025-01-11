using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtelYonetimSistemi.DAL;
using OtelYonetimSistemi.DOMAIN;

namespace OtelYonetimSistemi.SERVICE
{
    public class odaService
    {
        private readonly OdaDAO odaDAO;

        public odaService()
        {
            odaDAO = new OdaDAO();
        }

        public bool OdaKaydet(Oda oda)
        {
            
            if (string.IsNullOrEmpty(oda.OdaNumarasi))
                throw new Exception("Oda numarası boş olamaz!");

            if (string.IsNullOrEmpty(oda.OdaTipi))
                throw new Exception("Oda tipi belirlenmeli!");

            return odaDAO.OdaEkle(oda);
        }

        public bool OdaDurumGuncelle(int odaID, bool dolulukDurumu, bool temizlikDurumu)
        {
            Oda oda = odaDAO.OdaGetir(odaID);
            if (oda == null)
                throw new Exception("Oda bulunamadı!");

            oda.DolulukDurumu = dolulukDurumu;
            oda.OdaTemizlik = temizlikDurumu;

            return odaDAO.OdaGuncelle(oda);
        }

        public List<Oda> MusaitOdalariGetir()
        {
            return odaDAO.TumOdalariGetir().Where(o => !o.DolulukDurumu && o.OdaTemizlik).ToList();
        }
    }

}
