using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AngularAPI.Models;
using AngularAPI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        NorthwindContext _northwindContext;

        public BasketController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }
        [HttpPost()]
        public IActionResult Add(AddBasketVM addBasketVM)
        {
            try
            {
                Claim idClaim = User.Claims.FirstOrDefault(c => c.Type == "id");

                Basket basket = new Basket 
                { 
                    Price = addBasketVM.Price,
                    UrunId = addBasketVM.UrunId,
                    UserId = int.Parse(idClaim.Value)
                };
                _northwindContext.Baskets.Add(basket);
                _northwindContext.SaveChanges();
                return Ok(true);
            }
            catch
            {

                return Ok(false);
            }
        }


    }
}
