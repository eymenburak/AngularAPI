using System;
using System.Collections.Generic;

namespace AngularAPI.Models
{
    public partial class Bolge
    {
        public Bolge()
        {
            Bolgeler = new HashSet<Bolgeler>();
        }

        public int BolgeId { get; set; }
        public string BolgeTanimi { get; set; }

        public virtual ICollection<Bolgeler> Bolgeler { get; set; }
    }
}
