using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AngularAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        NorthwindContext _northwindContext;
        public ProductsController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }

        public IActionResult Get()
        {
            return Ok(_northwindContext.Urunler.Include(u => u.Tedarikci).Select(x => new { x.UrunAdi, x.Tedarikci.SirketAdi, x.UrunId }));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_northwindContext.Urunler.Include(x => x.Tedarikci).Include(x => x.Kategori).Select(x => new {
                x.Kategori.KategoriAdi,
                x.Tedarikci.SirketAdi,
                x.UrunAdi,
                x.BirimFiyati,
                x.BirimdekiMiktar,
                x.UrunId
            }).FirstOrDefault(x=>x.UrunId == id));
        }
    }
}
