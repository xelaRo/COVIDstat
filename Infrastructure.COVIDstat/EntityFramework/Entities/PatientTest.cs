using System;
using System.Collections.Generic;

namespace Infrastructure.COVIDstat.EntityFramework.Entities
{
    public partial class PatientTest
    {
        public Guid PatientTestId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime Date { get; set; }
        public int Result { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
