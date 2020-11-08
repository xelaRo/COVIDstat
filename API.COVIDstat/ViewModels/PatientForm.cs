using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.COVIDstat.ViewModels
{
    public class PatientForm
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Guid DistrictId { get; set; }
        public Guid[] SymptomsIds { get; set; }
        public int Age { get; set; }
        public string Telefon { get; set; }
    }
}
