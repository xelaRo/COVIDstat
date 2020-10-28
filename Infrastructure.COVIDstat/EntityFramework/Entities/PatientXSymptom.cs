using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.COVIDstat.EntityFramework.Entities
{
    public class PatientXSymptom
    {
        public Guid PatientXSymptomId { get; set; }
        public Guid PatientId { get; set; }
        public Guid SymptomId { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Symptom Symptom { get; set; }
    }
}
