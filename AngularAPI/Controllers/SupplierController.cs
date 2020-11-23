using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        NorthwindContext _northwindContext;
        public SupplierController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }

        public IActionResult Get()
        {
            return Ok(_northwindContext.Tedarikciler.ToList());
        }
    }
}
