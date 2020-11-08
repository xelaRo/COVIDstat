using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.COVIDstat.DTOs
{
    public class CountyDTO
    {
        public Guid CountyId { get; set; }
        public string Name { get; set; }
        public int PopulationNumber { get; set; }
    }
}
