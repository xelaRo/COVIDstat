using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.COVIDstat.JwtProvider
{
    public class RefreshToken
    {
        public string Token { get; set; }
        public DateTime ExpiresIn { get; set; }
        public DateTime Created { get; set; }
        public string GeneratedBy { get; set; }
    }
}
