using Infrastructure.COVIDstat.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.COVIDstat.EntityFramework.Repositories.Interfaces;

namespace Infrastructure.COVIDstat.EntityFramework.Repositories
{
    public class SymptomRepository : ISymptomRepository
    {
        private CovidStatDBContext _ctx;
        public SymptomRepository(CovidStatDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Symptom> GetSymptom(Guid symptomId)
        {

            var symptom = await _ctx.Symptom.Where(c => c.SymptomId == symptomId).FirstOrDefaultAsync();
            return symptom;
        }

        public async Task<List<Symptom>> GetSymptoms()
        {
            List<Symptom> Symptoms = await _ctx.Symptom.ToListAsync();
            return Symptoms;
        }

        public async Task AddSymptom(Symptom symptom)
        {
            _ctx.Symptom.Add(symptom);
        }
    }
}
