using AngularAPI.Models;
using AngularAPI.Models.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AngularAPI.Business
{
    public class TokenHandler
    {
        IConfiguration _configuration;
        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateAccessToken(User user)
        {
            Token token = new Token();
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecurityKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            token.Expiration = DateTime.Now.AddSeconds(20);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["Token:Audience"],
                expires: token.Expiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials,
                claims: new List<Claim>
                {
                    new Claim ("username",user.Username),
                    new Claim ("password",user.Password)
                }
             );
            JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = securityTokenHandler.WriteToken(securityToken);
            return token;
        }
        string CreateRefreshToken()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
    }
}
