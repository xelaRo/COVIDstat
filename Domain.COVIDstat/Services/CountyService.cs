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
    public class CountyService : ICountyService
    {
        private ICountyRepository _countyRepository;

        public CountyService(ICountyRepository countyRepository)
        {
            _countyRepository = countyRepository;
        }

        public async Task<List<CountyDTO>> GetDistricts()
        {
            var districts = await _countyRepository.GetCounties();

            return districts.Select(x => new CountyDTO()
            {
                CountyId = x.CountyId,
                Name = x.Name, 
                PopulationNumber = x.PopulationNumber
            }).ToList();
        }

        public async Task<CountyDTO> GetDistrict(Guid districtId)
        {
            if (districtId == null)
            {
                throw new ArgumentException($"The district id: {districtId} is null");
            }

            var result =  await _countyRepository.GetCounty(districtId);

            return new CountyDTO()
            {
                CountyId = result.CountyId,
                Name = result.Name,
                PopulationNumber = result.PopulationNumber
            };
        }
    }
}
