using Monolith.Domain.BusinessObjects;
using Monolith.Domain.Models;

namespace Monolith.Domain.Mappers
{
    public static class SignupModelToUsers
    {
        public static Appuser Map(SignupModel model)
        {
            return new Appuser
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Email = model.Email,
                Password = model.Password
            };
        }
    }
}