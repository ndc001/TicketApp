using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Database.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITicketRepository TicketRepository { get; }
        ITicketNoteRepository TicketNoteRepository { get; }
        ITicketTypeRepository TicketTypeRepository { get; }
        ITicketResolutionTypeRepository TicketResolutionTypeRepository { get; }
        ITicketStatusRepository TicketStatusRepository { get; }
        Task Save();
    }
}