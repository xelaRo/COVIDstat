using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.COVIDstat.EntityFramework.Entities
{
    public class Patient
    {
        public Guid PatientId { get; set; }
        public Guid DistrictId { get; set; }
        public Guid UserId { get; set; }
        public string LastName { get; set; }
        public string FisrtName { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
        public double TotalScore { get; set; }

        public virtual District City { get; set; }
        public virtual User User { get; set; }

    }
}
