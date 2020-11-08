using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.COVIDstat.EntityFramework.Enums;

namespace Domain.COVIDstat.DTOs
{
    public class PatientTestDTO
    {
        public Guid TestingFormId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime Date { get; set; }
        public Result Result { get; set; }
    }
}
