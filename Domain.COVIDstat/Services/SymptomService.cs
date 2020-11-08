using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.COVIDstat.DTOs;
using Domain.COVIDstat.Interfaces;
using Infrastructure.COVIDstat.EntityFramework.Repositories.Interfaces;

namespace Domain.COVIDstat.Services
{
    public class SymptomService : ISymptomService
    {
        private ISymptomRepository _symptomRepository;

        public SymptomService(ISymptomRepository symptomRepository)
        {
            _symptomRepository = symptomRepository;
        }

        public async Task<List<SymptomDTO>> GetSymptoms()
        {
            var symptoms = await _symptomRepository.GetSymptoms();

            return symptoms.Select(x => new SymptomDTO()
            {
                SymptomId = x.SymptomId,
                Name = x.Name,
                Score = x.Score
            }).ToList();
        }

        public async Task<SymptomDTO> GetSymptom(Guid symptomId)
        {
            if (symptomId == null)
            {
                throw new ArgumentException($"The symptom id: {symptomId} is null");
            }

            var result = await _symptomRepository.GetSymptom(symptomId);

            return new SymptomDTO()
            {
                SymptomId = result.SymptomId,
                Name = result.Name,
                Score = result.Score
            };
        }
    }
}
