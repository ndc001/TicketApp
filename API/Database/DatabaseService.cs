using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public static class DatabaseService
    {
        public static IServiceCollection ConfigureDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TicketDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("TicketConnectionString")));

            //Add Repositories

            return services;
            
        }
    }
}