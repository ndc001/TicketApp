using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ticket
{
    public class TicketDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

    }
}
