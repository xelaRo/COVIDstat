using System;
using System.Collections.Generic;

namespace Infrastructure.COVIDstat.EntityFramework.Entities
{
    public partial class County
    {
        public County()
        {
            Patient = new HashSet<Patient>();
        }

        public Guid CountyId { get; set; }
        public string Name { get; set; }
        public int PopulationNumber { get; set; }

        public virtual ICollection<Patient> Patient { get; set; }
    }
}
