using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database.Repositories.Interfaces;
using API.Domain;

namespace API.Database.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        private readonly TicketDbContext _dbContext;
        public TicketRepository(TicketDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Ticket> CreateTicket(Ticket ticket)
        {
            await _dbContext.AddAsync(ticket);
            return ticket;
        }

      
    }
}