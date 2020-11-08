using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.COVIDstat.DTOs
{
    public class PatientRegistrationFormDTO
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Guid DistrictId { get; set; }
        public Guid[] SymptomsIds { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
    }
}
