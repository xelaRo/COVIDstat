using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.COVIDstat.DTOs;

namespace Domain.COVIDstat.Interfaces
{
    public interface ISymptomService
    {
        Task<List<SymptomDTO>> GetSymptoms();
        Task<SymptomDTO> GetSymptom(Guid symptomId);
    }
}
