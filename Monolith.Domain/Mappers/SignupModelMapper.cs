using Monolith.Domain.BusinessObjects;
using Monolith.Domain.Models;

namespace Monolith.Domain.Mappers
{
    public static class SignupModelToUsers
    {
        public static AppUser Map(SignupModel model)
        {
            return new AppUser
            {
                FirstName = model.Firstname,
                LastName = model.Lastname,
                Email = model.Email,
                Password = model.Password
            };
        }
    }
}