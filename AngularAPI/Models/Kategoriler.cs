using System;
using System.Collections.Generic;

namespace AngularAPI.Models
{
    public partial class Kategoriler
    {
        public Kategoriler()
        {
            Urunler = new HashSet<Urunler>();
        }

        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public string Tanimi { get; set; }
        public byte[] Resim { get; set; }

        public virtual ICollection<Urunler> Urunler { get; set; }
    }
}
