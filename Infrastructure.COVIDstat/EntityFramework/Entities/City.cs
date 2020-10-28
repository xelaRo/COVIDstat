using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.COVIDstat.EntityFramework.Entities
{
    public class City
    {
        public Guid CityId { get; set; }
        public string Name { get; set; }
        public int PopulationNumber { get; set; }
    }
}
