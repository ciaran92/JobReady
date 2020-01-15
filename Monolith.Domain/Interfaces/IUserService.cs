using Monolith.Domain.BusinessObjects;
using Monolith.Domain.Contracts.V1.Requests;
using Monolith.Domain.Contracts.V1.Responses;
using Monolith.Domain.Models;

namespace Monolith.Domain.Interfaces
{
    public interface IUserService
    {
        SignUpResponse SignupUser(SignupModel model);
        LoginResponse Login(LoginModel model);
    }
}
