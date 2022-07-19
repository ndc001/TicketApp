using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;

namespace API.Database.Repositories.Interfaces
{
    public interface ITicket_Note_Repository : IGeneric_Repository<Ticket_Note>
    {
        //As of the current time, IGeneric_Repository has everything we need. (Future proof)
    }
}