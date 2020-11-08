using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.COVIDstat.DTOs;
using Domain.COVIDstat.Interfaces;
using Infrastructure.COVIDstat.EntityFramework;
using Infrastructure.COVIDstat.EntityFramework.Entities;
using Infrastructure.COVIDstat.EntityFramework.Enums;
using Infrastructure.COVIDstat.EntityFramework.Repositories.Interfaces;

namespace Domain.COVIDstat.Services
{
    public class PatientService : IPatientService
    {
        private readonly ISymptomRepository _symptomRepository;
        private readonly ICountyRepository _countyRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _uow;
        public PatientService(ISymptomRepository symptomRepository, ICountyRepository countyRepository, IPatientRepository patientRepository, IUnitOfWork uow)
        {
            _symptomRepository = symptomRepository;
            _countyRepository = countyRepository;
            _patientRepository = patientRepository;
            _uow = uow;
        }

        public async Task<FormDataDTO> GetPatientFormData()
        {
            var districts = await _countyRepository.GetCounties();
            var symptoms = await _symptomRepository.GetSymptoms();

            return new FormDataDTO()
            {
                Counties = districts.Select(x => new CountyDTO() {  CountyId = x.CountyId, Name = x.Name, PopulationNumber = x.PopulationNumber }).ToList(),
                Symptoms = symptoms.Select(x => new SymptomDTO() { SymptomId = x.SymptomId, Name = x.Name, Score = x.Score }).ToList()
            };
        }

        public async Task<Patient> AddPatientForm(PatientRegistrationFormDTO patientRegistrationFormDto)
        {
            var county = await _countyRepository.GetCounty(patientRegistrationFormDto.DistrictId);

            if (county == null)
            {
                throw  new ArgumentException($"Cannot find district with id: {patientRegistrationFormDto.DistrictId}");
            }

            Patient patient = new Patient();

            patient.FisrtName = patientRegistrationFormDto.FirstName;
            patient.LastName = patientRegistrationFormDto.LastName;
            patient.CountyId = county.CountyId;
            patient.Age = patientRegistrationFormDto.Age;
            patient.Phone = patientRegistrationFormDto.Phone;
            patient.State =(int) PatientState.NOTTESTED;
            patient.TotalScore = 0;

            await _patientRepository.AddPatient(patient);

            await _uow.SaveAsync();

            return patient;
        }
    }
}
