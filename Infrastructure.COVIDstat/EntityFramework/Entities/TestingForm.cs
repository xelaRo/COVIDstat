using Infrastructure.COVIDstat.EntityFramework.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.COVIDstat.EntityFramework.Entities
{
    public class TestingForm
    {
        public Guid TestingFormId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime Date { get; set; }
        public int MyProperty { get; set; }
        public Result Result { get; set; }
    }
}
