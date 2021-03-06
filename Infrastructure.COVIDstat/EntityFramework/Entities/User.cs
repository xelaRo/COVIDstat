﻿using System;
using System.Collections.Generic;

namespace Infrastructure.COVIDstat.EntityFramework.Entities
{
    public partial class User
    {
        public User()
        {
            Patient = new HashSet<Patient>();
        }

        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Patient> Patient { get; set; }
    }
}
