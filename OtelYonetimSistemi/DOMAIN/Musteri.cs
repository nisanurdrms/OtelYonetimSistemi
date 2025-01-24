using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelYonetimSistemi.DOMAIN
{
    public class Musteri
    {
        public int MusteriID { get; set; }
        public string AdSoyad { get; set; }
        public int TelNumarasi { get; set; }
        public int OdaNumarasi { get; set; }
        public DateTime? GirisTarihi { get; set; }
        public DateTime? CikisTarihi { get; set; }
        public bool FaturaDolulukDurumu { get; set; }
    }
}
