using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;

namespace API.Database.Repositories.Interfaces
{
    public interface ITicketNoteRepository : IGenericRepository<TicketNote>
    {
        Task<TicketNote> CreateTicketNote(TicketNote ticket_note);
    }
}