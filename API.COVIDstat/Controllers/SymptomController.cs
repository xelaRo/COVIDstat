using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.COVIDstat.Interfaces;
using Domain.COVIDstat.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.COVIDstat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SymptomController : ControllerBase
    {
        private readonly ISymptomService _symptomService;
        public SymptomController(ISymptomService symptomService)
        {
            _symptomService = symptomService;
        }

        [HttpGet]
        [Route("GetSymptom")]
        public async Task<IActionResult> GetSymptom(Guid symptomId)
        {
            if (symptomId == null)
            {
                return BadRequest();
            }

            var result = await _symptomService.GetSymptom(symptomId);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetSymptoms")]
        public async Task<IActionResult> GetSymptoms()
        {
            var result = await _symptomService.GetSymptoms();

            return Ok(result);
        }
    }
}
