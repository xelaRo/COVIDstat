using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.COVIDstat.ViewModels;
using Domain.COVIDstat.DTOs;
using Domain.COVIDstat.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.COVIDstat.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PatientTestController : ControllerBase
    {
        private readonly ITestingService _testingService;
        public PatientTestController(ITestingService testingService)
        {
            _testingService = testingService;
        }

        [HttpGet]
        [Route("RequestTesting")]
        public async Task<IActionResult> RequestTesting(Guid? userId)
        {
            if (userId == null)
            {
                return BadRequest();
            }

            var test = await _testingService.AddTest(userId);

            return Ok(test);
        }

        [HttpGet]
        [Route("GetTests")]
        public async Task<IActionResult> GetTests()
        {
            var tests = await _testingService.GetTests();

            return Ok(tests);
        }
    }
}
