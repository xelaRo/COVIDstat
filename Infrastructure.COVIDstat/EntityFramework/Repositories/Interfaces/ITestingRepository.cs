using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.COVIDstat.EntityFramework.Entities;

namespace Infrastructure.COVIDstat.EntityFramework.Repositories.Interfaces
{
    public interface ITestingRepository
    {
        Task<PatientTest> GetTest(Guid testingFormId);
        Task<List<PatientTest>> GetTests();
        Task AddTest(PatientTest testingForm);
    }
}
