using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database.Repositories.Interfaces;
using API.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Database.Repositories
{
    public class Ticket_Repository : Generic_Repository<Ticket>, ITicket_Repository
    {
        private readonly Ticket_DbContext dbContext;
        public Ticket_Repository(Ticket_DbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
       

        //We make sure that the whole ticket is not marked as dirty
        //We only mark the is_active property to be updated in the database
        //Head back to the Ticket_Repository to save changes
        public async Task Delete_Ticket(Ticket ticket)
        {            
            this.dbContext.Attach(ticket);
            this.dbContext.Entry(ticket).Property(x => x.is_active).IsModified = true;         
        }

      
    }
}