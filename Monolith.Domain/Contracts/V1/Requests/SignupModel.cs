namespace Monolith.Domain.Contracts.V1.Requests
{
    public class SignupModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
