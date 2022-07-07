using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API.Database
{
    public class Ticket_DbContext_Factory : IDesignTimeDbContextFactory<Ticket_DbContext>
    {
        public Ticket_DbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var builder = new DbContextOptionsBuilder<Ticket_DbContext>();
            var connectionString = configuration.GetConnectionString("TicketConnectionString");

            builder.UseSqlServer(connectionString);

            return new Ticket_DbContext(builder.Options);
        }
    }
}