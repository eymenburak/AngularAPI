using System;
using System.Collections.Generic;

namespace AngularAPI.Models
{
    public partial class SatislarinToplamMiktari
    {
        public decimal? SaleAmount { get; set; }
        public int SatisId { get; set; }
        public string SirketAdi { get; set; }
        public DateTime? SevkTarihi { get; set; }
    }
}
