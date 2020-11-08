using System;
using System.Collections.Generic;

namespace Infrastructure.COVIDstat.EntityFramework.Entities
{
    public partial class Patient
    {
        public Patient()
        {
            PatientTest = new HashSet<PatientTest>();
            PatientXsymptom = new HashSet<PatientXsymptom>();
        }

        public Guid PatientId { get; set; }
        public Guid CountyId { get; set; }
        public Guid? UserId { get; set; }
        public string LastName { get; set; }
        public string FisrtName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public int? State { get; set; }
        public double? TotalScore { get; set; }

        public virtual County County { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<PatientTest> PatientTest { get; set; }
        public virtual ICollection<PatientXsymptom> PatientXsymptom { get; set; }
    }
}
