using Infrastructure.COVIDstat.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.COVIDstat.EntityFramework
{
    public class COVIDstatContext: DbContext
    {
        public COVIDstatContext(DbContextOptions<COVIDstatContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<District> District { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<PatientXSymptom> PatientXSymptom { get; set; }
        public DbSet<Symptom> Symptom { get; set; }
        public DbSet<TestingForm> TestingForm { get; set; }
        public DbSet<User> User { get; set; }


    }
}
