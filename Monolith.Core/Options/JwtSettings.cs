using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monolith.Core.Options
{
    public class JwtSettings
    {
        public string SecurityKey { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public TimeSpan TokenLifeTime { get; set; }
    }
}
