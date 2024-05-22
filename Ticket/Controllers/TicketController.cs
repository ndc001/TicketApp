using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ticket.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketDbContext context;
        public TicketController(TicketDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetTicketFromName([FromQuery] string? name)
        {
            if (name == null)
            {
                List<Ticket> list = [];
                list = await context.Tickets.ToListAsync();
                return list.Count == 0 ? BadRequest("There are no tickets found.") : Ok(list);
            }
            if (ModelState.IsValid)
            {
                Ticket? ticket = await context.Tickets.FirstOrDefaultAsync(t => t.Name == name);
                return ticket == null ? BadRequest("No ticket could be found.") : Ok(ticket);
            }
            else
            {
                return BadRequest("No ticket could be found.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUpdateTicket([FromBody] TicketUpdateCreateDTO ticket)
        {
            bool ticketHasNoName = ticket.name == null;
            bool isANewTicket = ticket.isNewTicket == true;

            if (!ModelState.IsValid || (!isANewTicket && ticketHasNoName))
            {
                return BadRequest("Invalid Ticket.");
            }

            else
            {
                if (isANewTicket)
                {
                    Ticket newTicket = new()
                    {
                        Title = ticket.title,
                        Description = ticket.description,
                        TypeOfTicket = ticket.typeOfTicket
                    };

                    _ = await context.Tickets.AddAsync(newTicket);
                    _ = await context.SaveChangesAsync();

                }
                if (!isANewTicket && !ticketHasNoName)
                {
                    Ticket ticketToUpdate = await context.Tickets.FirstOrDefaultAsync(t => t.Name == ticket.name);

                    if (ticketToUpdate == null)
                    {
                        return BadRequest("Error.");
                    }

                    ticketToUpdate.Title = ticket.title;
                    ticketToUpdate.Description = ticket.description;

                    _ = await context.SaveChangesAsync();
                }
            }


            return Ok(ticket);
        }

    }
}
