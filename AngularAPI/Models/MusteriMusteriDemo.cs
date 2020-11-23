using System;
using System.Collections.Generic;

namespace AngularAPI.Models
{
    public partial class MusteriMusteriDemo
    {
        public string MusteriId { get; set; }
        public string MusteriTypeId { get; set; }

        public virtual Musteriler Musteri { get; set; }
        public virtual MusteriDemographics MusteriType { get; set; }
    }
}
