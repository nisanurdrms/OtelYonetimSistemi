using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelYonetimSistemi.DOMAIN
{
    public class Fatura
    {
        public int FaturaID { get; set; }
        public int RezervasyonID { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public decimal ToplamTutar { get; set; }
        public bool OdenmeDolulukDurumuu { get; set; }

        public Rezervasyon Rezervasyon { get; set; }
    }
}
