using System;
using System.Collections.Generic;

namespace Infrastructure.COVIDstat.EntityFramework.Entities
{
    public partial class Symptom
    {
        public Symptom()
        {
            PatientXsymptom = new HashSet<PatientXsymptom>();
        }

        public Guid SymptomId { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }

        public virtual ICollection<PatientXsymptom> PatientXsymptom { get; set; }
    }
}
