using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Monolith.Domain.BusinessObjects;
using Monolith.Domain.Interfaces;
using Monolith.Core.Options;

namespace Monolith.Core.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly JwtSettings _jwtSettings; 

        public AuthService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        public string NewJwtToken(AppUser user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(type: "id", user.UserId.ToString())
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey));
            var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken
            (
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.UtcNow.Add(_jwtSettings.TokenLifeTime),
                claims: claims,
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