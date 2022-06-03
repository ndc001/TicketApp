using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public class TicketDbContext : DbContext
    {
        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketDbContext).Assembly);
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketNote> TicketNotes { get; set; }
        public DbSet<TicketResolutionType> TicketResolutionTypes { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
    }
}