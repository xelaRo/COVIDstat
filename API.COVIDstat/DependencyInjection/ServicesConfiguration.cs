using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.COVIDstat.Interfaces;
using Domain.COVIDstat.Services;
using Microsoft.Extensions.DependencyInjection;

namespace API.COVIDstat.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureServiceCollection(this IServiceCollection service)
        {
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<ITestingService, TestingService>();
            service.AddTransient<IPatientService, PatientService>();
            service.AddTransient<ICountyService, CountyService>();
            service.AddTransient<ISymptomService, SymptomService>();

            return service;
        }
    }
}
