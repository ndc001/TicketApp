using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Database.Repositories.Interfaces
{
    public interface IUnit_Of_Work : IDisposable
    {
        ITicket_Repository ticket_repository { get; }
        ITicket_Note_Repository ticket_note_repository { get; }
        
        Task Save();
    }
}