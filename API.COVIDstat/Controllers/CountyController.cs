using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.COVIDstat.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.COVIDstat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountyController : ControllerBase
    {
        private readonly ICountyService _countyService;
        public CountyController(ICountyService countyService)
        {
            _countyService = countyService;
        }

        [HttpGet]
        [Route("GetCounties")]
        public async Task<IActionResult> GetCounties()
        {
            var districts = await _countyService.GetDistricts();

            return Ok(districts);
        }

        [HttpGet]
        [Route("GetCounty")]
        public async Task<IActionResult> GetCounty(Guid districtId)
        {
            var districts = await  _countyService.GetDistrict(districtId);

            return Ok(districts);
        }
    }
}
