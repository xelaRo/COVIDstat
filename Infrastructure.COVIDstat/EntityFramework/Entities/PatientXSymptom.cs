﻿using System;
using System.Collections.Generic;

namespace Infrastructure.COVIDstat.EntityFramework.Entities
{
    public partial class PatientXsymptom
    {
        public Guid PatientXsymptomId { get; set; }
        public Guid PatientId { get; set; }
        public Guid SymptomId { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Symptom Symptom { get; set; }
    }
}
