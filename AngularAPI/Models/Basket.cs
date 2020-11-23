using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularAPI.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public int UrunId { get; set; }
        public int UserId { get; set; }
        public int Price { get; set; }
        public Urunler Product { get; set; }

        public User User { get; set; }
    }
}
