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
        public async Task<Ticket> Create_Ticket(Ticket ticket)
        {
            await this.dbContext.AddAsync(ticket);
            return ticket;
        }

        public async Task<List<Ticket>> Get_Tickets()
        {
            return await this.dbContext.tickets.ToListAsync();
        }

        public async Task<Ticket> Get_Ticket_Details(int id)
        {
            return await this.dbContext.tickets.FirstOrDefaultAsync(x => x.ticket_id == id);
        }

        public async Task Delete_Ticket(Ticket ticket)
        {
            
            ticket.is_active = false;
            this.dbContext.Entry(ticket).State = EntityState.Modified;
           
             
        }

      
    }
}