﻿using System;
using System.Collections.Generic;

namespace AngularAPI.Models
{
    public partial class OzetYillikSatislar
    {
        public DateTime? SevkTarihi { get; set; }
        public int SatisId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
