using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Microsoft.IdentityModel.Tokens;
using Service.Models;

namespace Service.Models
{
    public class JWTManager
    {
        private const string _secret = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
        public string GenerateToken(string userName,string Password,int expiresInMinutes=20)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name,userName)
            });
            var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(_secret));

            var token = (JwtSecurityToken)
            tokenHandler.CreateJwtSecurityToken(issuer: "http://localhost:62481", audience: "http://localhost:62481", subject: claimsIdentity, notBefore: DateTime.UtcNow, expires: DateTime.UtcNow.AddMinutes(expiresInMinutes), signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature));
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}