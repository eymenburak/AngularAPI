using System;
using System.Collections.Generic;

namespace AngularAPI.Models
{
    public partial class Nakliyeciler
    {
        public Nakliyeciler()
        {
            Satislar = new HashSet<Satislar>();
        }

        public int NakliyeciId { get; set; }
        public string SirketAdi { get; set; }
        public string Telefon { get; set; }

        public virtual ICollection<Satislar> Satislar { get; set; }
    }
}
