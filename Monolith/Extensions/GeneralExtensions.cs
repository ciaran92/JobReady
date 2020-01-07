using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Monolith.Extensions
{
    public static class GeneralExtensions
    {
        public static string GetUserById(this HttpContext httpContext)
        {
            if(httpContext.User == null)
            {
                return string.Empty;
            }

            return httpContext.User.Claims.Single(x => x.Type == "id").Value;
        }
    }
}
