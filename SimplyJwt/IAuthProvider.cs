using System;
using System.Collections.Generic;

namespace SimplyJwt
{
    public interface IAuthProvider
    {
        public string GenerateJsonWebToken(IDictionary<string, string> myClaims);
        public IDictionary<string, string> ValidateToken(string jwtToken, List<string> keys);
    }
}
