using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Monolith.Domain.Interfaces;

namespace Monolith.Core.Services.Authentication
{
    public class AuthService : IAuthService
    {
        // TODO: move key, issuer & audience to appSettings file
        public string NewJwtToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretkeySuperDoopeSecretNeverBeCracked147468gnvjhfnd"));
            var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken
            (
                issuer: "http://localhost:5001",
                audience: "https://jobready.com",
                expires: DateTime.Now.AddMinutes(30),
                claims: null,
                signingCredentials: signInCred
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string NewRefreshToken()
        {
            throw new System.NotImplementedException();
        }
    }
}