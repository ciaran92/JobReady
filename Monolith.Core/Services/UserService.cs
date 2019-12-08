using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Monolith.Domain.Context;
using Monolith.Domain.Interfaces;
using Monolith.Domain.Mappers;
using Monolith.Domain.Models;

namespace Monolith.Core.Services
{
    public class UserService : IUserService
    {
        private readonly PrimarydbContext _context;
        
        public UserService(PrimarydbContext context)
        {
            _context = context;
        }
        
        public SignUpResponse SignupUser(SignupModel model)
        {
            bool userExists = _context.AppUser.Select(x => x.Email == model.Email).FirstOrDefault();
            
            if (userExists)
            {
                return new SignUpResponse{Success = false, Message = "Email Already Exists"};
            }
            
            // Map it
            var user = SignupModelToUsers.Map(model);
            user.Salt = Salt();
            user.Password = HashPassword(user.Password, user.Salt);
            
            // Save to the database
            _context.AppUser.Add(user);
            _context.SaveChanges();
            
            return new SignUpResponse
            {
                Success = true,
                Message = "Sign Up Successful"
            };
        }

        public LoginResponse Login(LoginModel model)
        {
            var user = _context.AppUser.SingleOrDefault(x => x.Email == model.Email);
            
            if (user == null)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "Email doesn't exist"
                };
            }
                
            if(!ValidatePassword(model.Password, user.Salt, user.Password))
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "Password Incorrect"
                };
            }
            
            return new LoginResponse
            {
                Success = true,
                Message = "Login Successful"
            };
        }
        

        private string Salt()
        {
            byte[] salt = new byte[128 / 8];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(salt);
                return Convert.ToBase64String(salt);
            }
        }
        
        private string HashPassword(string password, string salt)
        {
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.UTF8.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8)
            );

            return hashedPassword;
        }
        
        private bool ValidatePassword(string password, string salt, string passwordHash)
        {
            return HashPassword(password, salt) == passwordHash;
        }
    }
}
