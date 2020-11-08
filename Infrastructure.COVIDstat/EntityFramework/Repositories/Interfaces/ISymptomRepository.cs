using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.COVIDstat.EntityFramework.Entities;

namespace Infrastructure.COVIDstat.EntityFramework.Repositories.Interfaces
{
    public interface ISymptomRepository
    {
        Task<Symptom> GetSymptom(Guid symptomId);
        Task<List<Symptom>> GetSymptoms();
    }
}
