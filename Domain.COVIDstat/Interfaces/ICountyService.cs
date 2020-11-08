using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.COVIDstat.DTOs;

namespace Domain.COVIDstat.Interfaces
{
    public interface ICountyService
    {
        Task<List<CountyDTO>> GetDistricts();
        Task<CountyDTO> GetDistrict(Guid districtId);
    }
}
