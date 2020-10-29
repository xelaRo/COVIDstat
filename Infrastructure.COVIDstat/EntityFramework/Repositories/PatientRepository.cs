using Infrastructure.COVIDstat.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.COVIDstat.EntityFramework.Repositories
{
    public class PatientRepository
    {
        private COVIDstatContext _ctx;
        public PatientRepository(COVIDstatContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Patient> GetPatient(Guid patientId)
        {

            var patient = await _ctx.Patient.Where(c => c.PatientId == patientId).FirstOrDefaultAsync();
            return patient;
        }

        public async Task<List<Patient>> GetPatientList()
        {
            List<Patient> Pacients = await _ctx.Patient.ToListAsync();
            return Pacients;
        }

        public async Task AddPatient(Patient patient)
        {
            _ctx.Patient.Add(patient);
        }

    }
}
