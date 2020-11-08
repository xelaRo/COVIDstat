using Infrastructure.COVIDstat.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.COVIDstat.EntityFramework.Repositories.Interfaces;

namespace Infrastructure.COVIDstat.EntityFramework.Repositories
{
    public class CountyRepository : ICountyRepository
    {
        private CovidStatDBContext _ctx; 
        public CountyRepository(CovidStatDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<County> GetCounty (Guid countryId)
        {

            var country = await _ctx.County.Where(c => c.CountyId == countryId).FirstOrDefaultAsync();
            return country;
        }

        public async Task<List<County>> GetCounties()
        {
            List<County> countries = await _ctx.County.ToListAsync();
            return countries;
        }

        //public async Task AddCity(District city)
        //{
        //    _ctx.City.Add(city);
        //}
            
    }
}
