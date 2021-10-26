using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyJwt
{
    class AuthConfigModel
    {
        public string JwtKey { get; set; }
        public string JwtIssuer { get; set; }
        public int Timeout { get; set; }
    }
}
