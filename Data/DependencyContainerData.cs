using Data.Data;
using Data.Interfaz;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class DependencyContainerData
    {
        public static IServiceCollection AddDataDependency(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<EfectyContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("ConnectionMain")));
            services.AddScoped<IPersonaData, PersonaData>();
            return services;
        }
    }
}
