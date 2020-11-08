using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.COVIDstat.EntityFramework.Entities;

namespace Infrastructure.COVIDstat.EntityFramework.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<Patient> GetPatient(Guid patientId);
        Task<Patient> GetPatientBy(Guid userId);
        Task<List<Patient>> GetPatientList();
        Task AddPatient(Patient patient);
    }
}
