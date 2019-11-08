namespace Monolith.Domain.Interfaces
{
    public interface IAuthService
    {
        string NewJwtToken(string email);
        string NewRefreshToken();
    }
}