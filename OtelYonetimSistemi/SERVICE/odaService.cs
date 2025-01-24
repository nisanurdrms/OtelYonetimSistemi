using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtelYonetimSistemi.DAL;
using OtelYonetimSistemi.DOMAIN;

namespace OtelYonetimSistemi.SERVICE
{
    public class OdaService
    {
        public OdaDAO odaDAO;

        public OdaService()
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

        public bool OdaDolulukDurumuGuncelle(int odaID, bool DolulukDurumu, bool temizlikDolulukDurumuu)
        {
            Oda oda = odaDAO.OdaGetir(odaID);
            if (oda == null)
                throw new Exception("Oda bulunamadı!");

            oda.DolulukDurumu = DolulukDurumu;
            oda.OdaTemizlik = temizlikDolulukDurumuu;

            return odaDAO.OdaGuncelle(oda);
        }

        public List<Oda> MusaitOdalariGetir()
        {
            return odaDAO.TumOdalariGetir().Where(o => !o.DolulukDurumu && o.OdaTemizlik).ToList();
        }

        internal IEnumerable<object> TumOdalariGetir()
        {
            throw new NotImplementedException();
        }
    }

}
