using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.COVIDstat.EntityFramework.Entities
{
    class Symptom
    {
        public Guid SymptomId { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
