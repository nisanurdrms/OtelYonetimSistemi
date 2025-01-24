using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelYonetimSistemi.DOMAIN
{
    public class Rezervasyon
    {
            public int RezervasyonID { get; set; }
            public int OdaID { get; set; }
            public int MusteriID { get; set; }
            public DateTime GirisTarihi { get; set; }
            public DateTime CikisTarihi { get; set; }
            public decimal ToplamTutar { get; set; }
            public string MusteriAdSoyad { get; set; }
            public string MusteriTelefon { get; set; }
            public string OdaNumarasi { get; set; }
       
    

        public Musteri Musteri { get; set; }
        public Oda Oda { get; set; }
        public Fatura Fatura { get; set; }
    }

}
