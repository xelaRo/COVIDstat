using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Infrastructure.COVIDstat.EntityFramework.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
