using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.COVIDstat.EntityFramework.Entities;

namespace Infrastructure.COVIDstat.EntityFramework.Repositories.Interfaces
{
    public interface ICountyRepository
    {
        Task<County> GetCounty(Guid districtId);
        Task<List<County>> GetCounties();
    }
}
