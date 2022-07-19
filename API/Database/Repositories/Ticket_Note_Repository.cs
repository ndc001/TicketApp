using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database.Repositories.Interfaces;
using API.Domain;

namespace API.Database.Repositories
{
    public class Ticket_Note_Repository : Generic_Repository<Ticket_Note>, ITicket_Note_Repository
    {
        //Currently everything is covered in the Generic_Repository
        private readonly Ticket_DbContext dbContext;
        public Ticket_Note_Repository(Ticket_DbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        

    }
}