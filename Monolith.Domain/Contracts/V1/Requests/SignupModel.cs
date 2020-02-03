using System.ComponentModel.DataAnnotations;

namespace Monolith.Domain.Contracts.V1.Requests
{
    public class SignupModel
    {
        [Required]
        public string Firstname { get; set; }
        
        [Required]
        public string Lastname { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
