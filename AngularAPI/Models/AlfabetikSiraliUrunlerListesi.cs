﻿using System;
using System.Collections.Generic;

namespace AngularAPI.Models
{
    public partial class AlfabetikSiraliUrunlerListesi
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int? TedarikciId { get; set; }
        public int? KategoriId { get; set; }
        public string BirimdekiMiktar { get; set; }
        public decimal? BirimFiyati { get; set; }
        public short? HedefStokDuzeyi { get; set; }
        public short? YeniSatis { get; set; }
        public short? EnAzYenidenSatisMikatari { get; set; }
        public bool Sonlandi { get; set; }
        public string KategoriAdi { get; set; }
    }
}
