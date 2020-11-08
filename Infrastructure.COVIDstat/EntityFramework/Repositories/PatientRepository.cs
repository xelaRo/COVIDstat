using Infrastructure.COVIDstat.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.COVIDstat.EntityFramework.Repositories.Interfaces;

namespace Infrastructure.COVIDstat.EntityFramework.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly CovidStatDBContext _ctx;
        public PatientRepository(CovidStatDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Patient> GetPatient(Guid patientId)
        {

            var patient = await _ctx.Patient.Where(c => c.PatientId == patientId).FirstOrDefaultAsync();
            return patient;
        }

        public async Task<Patient> GetPatientBy(Guid userId)
        {

            var patient = await _ctx.Patient.Where(c => c.UserId == userId).FirstOrDefaultAsync();
            return patient;
        }


        public async Task<List<Patient>> GetPatientList()
        {
            List<Patient> patients = await _ctx.Patient.ToListAsync();
            return patients;
        }

        public async Task AddPatient(Patient patient)
        {
            await _ctx.Patient.AddAsync(patient);
        }

    }
}
