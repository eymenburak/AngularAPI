using System;
using System.Collections.Generic;

namespace AngularAPI.Models
{
    public partial class MusteriDemographics
    {
        public MusteriDemographics()
        {
            MusteriMusteriDemo = new HashSet<MusteriMusteriDemo>();
        }

        public string MusteriTypeId { get; set; }
        public string MusteriDesc { get; set; }

        public virtual ICollection<MusteriMusteriDemo> MusteriMusteriDemo { get; set; }
    }
}
