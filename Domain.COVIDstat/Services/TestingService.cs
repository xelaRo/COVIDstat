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
    public class TestingService : ITestingService
    {
        private readonly ITestingRepository _testingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _uow;
        public TestingService(ITestingRepository testingRepository, IUserRepository userRepository, IPatientRepository patientRepository, IUnitOfWork uow)
        {
            _testingRepository = testingRepository;
            _userRepository = userRepository;
            _patientRepository = patientRepository;
            _uow = uow;
        }
        public async Task<PatientTestDTO> AddTest(Guid? userId)
        {
            var user = await _userRepository.GetUser(userId.Value);

            if (user == null)
            {
                throw new ArgumentException($"Cannot find user with id: {userId}");
            }

            var patient = await _patientRepository.GetPatientBy(user.UserId);

            if (patient == null)
            {
                throw new ArgumentException($"Cannot find patient with user id: {user.UserId}");
            }

            PatientTestDTO patientTest = new PatientTestDTO
            {
                TestingFormId = Guid.NewGuid(),
                PatientId = patient.PatientId,
                Date = DateTime.Now,
                Result = Result.PENDING
            };



            await  _testingRepository.AddTest(new PatientTest()
            {
                PatientTestId = patientTest.TestingFormId,
                PatientId = patientTest.PatientId,
                Date =  patientTest.Date,
                Result = (int)patientTest.Result
            });

            return patientTest;

        }

        public async Task<List<PatientTest>> GetTests()
        {
            var tests = await _testingRepository.GetTests();

            return tests;
;        }

    }
}
