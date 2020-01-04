using Monolith.Domain.BusinessObjects;

namespace Monolith.Domain.Interfaces
{
    public interface IAuthService
    {
        string NewJwtToken(AppUser user);
        string NewRefreshToken();
    }
}