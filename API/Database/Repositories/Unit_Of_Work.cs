using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database.Repositories.Interfaces;

namespace API.Database.Repositories
{
    public class Unit_Of_Work : IUnit_Of_Work
    {
        private readonly Ticket_DbContext dbcontext;
        private ITicket_Repository Ticket_repository;
        private ITicket_Note_Repository Ticket_note_repository;
       

        public Unit_Of_Work(Ticket_DbContext dbContext)
        {
            this.dbcontext = dbContext;
        }

        public ITicket_Repository ticket_repository =>
        Ticket_repository ??= new Ticket_Repository(this.dbcontext);

       public ITicket_Note_Repository ticket_note_repository =>
        Ticket_note_repository ??= new Ticket_Note_Repository(this.dbcontext);


        public void Dispose()
        {
            this.dbcontext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await this.dbcontext.SaveChangesAsync();
        }
    }
}