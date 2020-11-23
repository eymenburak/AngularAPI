using System;
using System.Collections.Generic;

namespace AngularAPI.Models
{
    public partial class KategorilereGoreUrunler
    {
        public string KategoriAdi { get; set; }
        public string UrunAdi { get; set; }
        public string BirimdekiMiktar { get; set; }
        public short? HedefStokDuzeyi { get; set; }
        public bool Sonlandi { get; set; }
    }
}
