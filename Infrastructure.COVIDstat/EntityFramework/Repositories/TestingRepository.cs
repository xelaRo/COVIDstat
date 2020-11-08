using Infrastructure.COVIDstat.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.COVIDstat.EntityFramework.Repositories.Interfaces;

namespace Infrastructure.COVIDstat.EntityFramework.Repositories
{
    public class TestingRepository : ITestingRepository
    {
        private CovidStatDBContext _ctx;
        public TestingRepository(CovidStatDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<PatientTest> GetTest(Guid testingFormId)
        {

            var test = await _ctx.PatientTest.Where(c => c.PatientTestId == testingFormId).FirstOrDefaultAsync();
            return test;
        }

        public async Task<List<PatientTest>> GetTests()
        {
            List<PatientTest> tests = await _ctx.PatientTest.ToListAsync();
            return tests;
        }

        public async Task AddTest(PatientTest testingForm)
        {
            await _ctx.PatientTest.AddAsync(testingForm);
        }
    }
}
