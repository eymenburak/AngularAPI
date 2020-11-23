using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularAPI.Business;
using AngularAPI.Models;
using AngularAPI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AngularAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        NorthwindContext _northwindContext;
        IConfiguration _configuration;
        public UsersController(NorthwindContext northwindContext, IConfiguration configuration)
        {
            _configuration = configuration;
            _northwindContext = northwindContext;
        }

        [HttpPost("[action]")]
        public IActionResult Register(UserCreateOrLoginVM userCreateOrLoginVM)
        {
            if (!_northwindContext.Users.Any(u => u.Username.ToLower() == userCreateOrLoginVM.Username.ToLower()))
            {
                _northwindContext.Users.Add(new Models.User {

                    Password = userCreateOrLoginVM.Password,
                    Username = userCreateOrLoginVM.Username


                });

                return Ok(_northwindContext.SaveChanges() > 0 ? "successfull" : "unsuccessfull");
            }

            return Ok("User already registered");

        }

        [HttpPost("[action]")]
        public IActionResult Login(UserCreateOrLoginVM model)
        {
            User user = _northwindContext.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
            if (user!=null)
            {
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddSeconds(30);
                _northwindContext.SaveChanges();
                return Ok(token);
            }

            return Ok(new
            {
                Message = "Username or Password wrong"
            });
        }

        [HttpGet("[action]")]

        public IActionResult RefreshTokenLogin(string refreshToken)
        {
            User user = _northwindContext.Users.FirstOrDefault(x => x.RefreshToken == refreshToken);
            if (user != null && user.RefreshTokenEndDate > DateTime.UtcNow)
            {
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddSeconds(10);

                _northwindContext.SaveChanges();
                return Ok(token);
            }
            return new StatusCodeResult(401);
        }
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult ValidAuthorize()
        {
            return Ok();
        }
    }
}
