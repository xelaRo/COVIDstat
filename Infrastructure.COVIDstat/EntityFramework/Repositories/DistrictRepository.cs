using Infrastructure.COVIDstat.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.COVIDstat.EntityFramework.Repositories
{
    public class DistrictRepository
    {
        private COVIDstatContext _ctx; 
        public DistrictRepository(COVIDstatContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<District> GetDistrict (Guid districtId)
        {

            var city = await _ctx.District.Where(c => c.DistrictId == districtId).FirstOrDefaultAsync();
            return city;
        }

        public async Task<List<District>> GetDistrictList()
        {
            List<District> Districts = await _ctx.District.ToListAsync();
            return Districts;
        }

        //public async Task AddCity(District city)
        //{
        //    _ctx.City.Add(city);
        //}
            
    }
}
