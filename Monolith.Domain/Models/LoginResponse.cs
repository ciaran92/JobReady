﻿namespace Monolith.Domain.Models
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string JwtToken { get; set; }
    }
}