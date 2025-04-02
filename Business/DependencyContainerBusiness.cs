using Business.Business;
using Business.Interfaz;
using Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class DependencyContainerBusiness
    {
        public static IServiceCollection AddDataDependency(this IServiceCollection services)
        {
            services.AddScoped<IPersonaBusiness, PersonaBusiness>();
            return services;
        }
    }
}
