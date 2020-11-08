using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.COVIDstat.DTOs
{
    public class SymptomDTO
    {
        public Guid SymptomId { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
