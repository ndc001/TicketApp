using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database.Repositories.Interfaces;

namespace API.Database.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TicketDbContext _dbcontext;
        private ITicketRepository _ticketRepository;
        private ITicketNoteRepository _ticketNoteRepository;
        private ITicketTypeRepository _ticketTypeRepository;
        private ITicketStatusRepository _ticketStatusRepository;
        private ITicketResolutionTypeRepository _ticketResolutionTypeRepository;

        public UnitOfWork(TicketDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public ITicketRepository TicketRepository =>
        _ticketRepository ??= new TicketRepository(_dbcontext);

       public ITicketNoteRepository TicketNoteRepository =>
        _ticketNoteRepository ??= new TicketNoteRepository(_dbcontext);

        public ITicketTypeRepository TicketTypeRepository =>
        _ticketTypeRepository ??= new TicketTypeRepository(_dbcontext);

        public ITicketStatusRepository TicketStatusRepository =>
        _ticketStatusRepository ??= new TicketStatusRepository(_dbcontext);

        public ITicketResolutionTypeRepository TicketResolutionTypeRepository =>
        _ticketResolutionTypeRepository ??= new TicketResolutionTypeRepository(_dbcontext); 

        public void Dispose()
        {
            _dbcontext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}