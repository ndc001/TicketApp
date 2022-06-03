using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database.Repositories.Interfaces;
using API.Domain;

namespace API.Database.Repositories
{
    public class TicketNoteRepository : GenericRepository<TicketNote>, ITicketNoteRepository
    {
        private readonly TicketDbContext _dbContext;
        public TicketNoteRepository(TicketDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TicketNote> CreateTicketNote(TicketNote ticket_note)
        {
            await _dbContext.AddAsync(ticket_note);
            return ticket_note;
        }
    }
}