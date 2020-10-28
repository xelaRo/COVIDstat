using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.COVIDstat.EntityFramework.Entities
{
    class PatientXSymptom
    {
        public Guid PatientXSymptomId { get; set; }
        public Guid PatientId { get; set; }
        public Guid SymptomId { get; set; }
    }
}
