using System.ComponentModel.DataAnnotations;

namespace Monolith.Domain.Contracts.V1.Requests
{
    public class LoginModel
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}