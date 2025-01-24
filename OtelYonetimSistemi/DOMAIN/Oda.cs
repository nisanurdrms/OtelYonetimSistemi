using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelYonetimSistemi.DOMAIN
{
    public class Oda
    {
        public int OdaID { get; set; }
        public string OdaNumarasi { get; set; }
        public bool DolulukDolulukDurumuu { get; set; }
        public string OdaTipi { get; set; }
        public bool OdaTemizlik { get; set; }
    }
}
