using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.COVIDstat.EntityFramework.Entities
{
    public class Symptom
    {
        public Guid SymptomId { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
