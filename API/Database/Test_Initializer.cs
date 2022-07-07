using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;

namespace API.Database
{
    public class Test_Initializer
    {
        public static void Initialize(Ticket_DbContext dbContext)
        {
            if(dbContext.tickets.Any())
            {
                return;
            }

            var first_Ticket = new Ticket
            {
                ticket_description = "This is another description",
                title = "First Ticket",
                ticket_type = Ticket_Type.hardware,
                assigned_date = null,
                resolved_date = null,
                
                
                
            };          


            dbContext.tickets.AddAsync(first_Ticket);
            dbContext.SaveChanges();
        }
        
        }
    }