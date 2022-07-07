using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public class Ticket_DbContext : DbContext
    {
        public Ticket_DbContext(DbContextOptions<Ticket_DbContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Ticket_DbContext).Assembly);
        }

        public DbSet<Ticket> tickets { get; set; }
        public DbSet<Ticket_Note> ticket_notes { get; set; }
        
    }
}