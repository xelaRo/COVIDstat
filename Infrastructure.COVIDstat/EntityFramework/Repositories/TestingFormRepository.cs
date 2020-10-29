using Infrastructure.COVIDstat.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.COVIDstat.EntityFramework.Repositories
{
    public class TestingFormRepository
    {
        private COVIDstatContext _ctx;
        public TestingFormRepository(COVIDstatContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<TestingForm> GetTestingForm(Guid testingFormId)
        {

            var testingForm = await _ctx.TestingForm.Where(c => c.TestingFormId == testingFormId).FirstOrDefaultAsync();
            return testingForm;
        }

        public async Task<List<TestingForm>> GetTestingFormList()
        {
            List<TestingForm> TestingForms = await _ctx.TestingForm.ToListAsync();
            return TestingForms;
        }

        public async Task AddTestingForm(TestingForm testingForm)
        {
            _ctx.TestingForm.Add(testingForm);
        }
    }
}
