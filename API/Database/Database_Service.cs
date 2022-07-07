using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database.Repositories;
using API.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public static class Database_Service
    {
        public static IServiceCollection Configure_Database_Services(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Ticket_DbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("TicketConnectionString")));

            //Add Repositories

            services.AddScoped(typeof(IGeneric_Repository<>), typeof(Generic_Repository<>));
            services.AddScoped<IUnit_Of_Work, Unit_Of_Work>();
            services.AddScoped<ITicket_Repository, Ticket_Repository>();
            services.AddScoped<ITicket_Note_Repository, Ticket_Note_Repository>();

            return services;
            
        }
    }
}