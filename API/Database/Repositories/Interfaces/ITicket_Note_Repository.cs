using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;

namespace API.Database.Repositories.Interfaces
{
    public interface ITicket_Note_Repository : IGeneric_Repository<Ticket_Note>
    {
        Task<Ticket_Note> Create_Ticket_Note(Ticket_Note ticket_note);
    }
}