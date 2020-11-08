using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.COVIDstat.DTOs
{
    public class FormDataDTO
    {
        public List<CountyDTO> Counties { get; set; }
        public List<SymptomDTO> Symptoms { get; set; }
    }
}
