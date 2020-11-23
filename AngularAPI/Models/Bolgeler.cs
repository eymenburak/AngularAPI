using System;
using System.Collections.Generic;

namespace AngularAPI.Models
{
    public partial class Bolgeler
    {
        public Bolgeler()
        {
            PersonelBolgeler = new HashSet<PersonelBolgeler>();
        }

        public string TerritoryId { get; set; }
        public string TerritoryTanimi { get; set; }
        public int BolgeId { get; set; }

        public virtual Bolge Bolge { get; set; }
        public virtual ICollection<PersonelBolgeler> PersonelBolgeler { get; set; }
    }
}
