using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.COVIDstat.EntityFramework;
using Infrastructure.COVIDstat.EntityFramework.Repositories;
using Infrastructure.COVIDstat.EntityFramework.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace API.COVIDstat.DependencyInjection
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection ConfigureRepositoryCollection(this IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<ICountyRepository, CountyRepository>();
            service.AddScoped<ISymptomRepository, SymptomRepository>();
            service.AddScoped<ITestingRepository, TestingRepository>();
            service.AddScoped<IPatientRepository, PatientRepository>();
            return service;
        }
    }
}
