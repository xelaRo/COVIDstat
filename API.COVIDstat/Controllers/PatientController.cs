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
    public class PatientController  : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        [Route("GetPatientFormData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPatientFormData()
        {
            var result = await _patientService.GetPatientFormData();
            return Ok(result);
        }

        [HttpPost]
        [Route("AddPatientForm")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddPatientForm([FromBody] PatientForm form)
        {
            if (string.IsNullOrEmpty(form.LastName) || string.IsNullOrEmpty(form.FirstName) || form.Age == 0
                || form.DistrictId == null || form.SymptomsIds == null || form.SymptomsIds.Length == 0
                || string.IsNullOrEmpty(form.Telefon))
            {
                return BadRequest();
            }

            PatientRegistrationFormDTO patientRegistrationFormDto = new PatientRegistrationFormDTO()
            {
                LastName = form.LastName,
                FirstName = form.FirstName,
                Age = form.Age,
                DistrictId = form.DistrictId,
                SymptomsIds = form.SymptomsIds,
                Phone = form.Telefon
            };

            var result = await _patientService.AddPatientForm(patientRegistrationFormDto);
            return Ok(result);
        }
    }
}
