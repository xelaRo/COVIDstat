using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.COVIDstat.DTOs;
using Infrastructure.COVIDstat.EntityFramework.Entities;

namespace Domain.COVIDstat.Interfaces
{
    public interface ITestingService
    {
        Task<PatientTestDTO> AddTest(Guid? userId);
        Task<List<PatientTest>> GetTests();
    }
}
