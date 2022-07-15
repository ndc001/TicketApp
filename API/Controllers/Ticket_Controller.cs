using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.DTOs.TicketDtos;
using API.DTOs.TicketNoteDtos;
using API.Requests;
using API.Requests.Commands;
using API.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
   // [Authorize]
    public class TicketController : Controller
    {
        //private readonly ILogger<TicketController> _logger;
        private readonly IMediator mediator;
        
        public TicketController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("CreateTicket")]
        public async Task<ActionResult<Base_Command_Response>> Post([FromBody] Create_Ticket_Dto create_ticket_dto)
        {
            var command = new Create_Ticket_Command { ticket_dto = create_ticket_dto };
            var response = await this.mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateTicketNote")]
        public async Task<ActionResult<Create_Ticket_Note_Command_Response>> Post([FromBody] Create_Ticket_Note_Dto create_note)
        {
            var command = new Create_Ticket_Note_Command {ticket_note_dto = create_note};
            var response = await this.mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        [Route("DeleteTicket")]
        public async Task<ActionResult<Base_Command_Response>> Delete_Ticket([FromBody] Delete_Ticket_Dto delete_ticket_dto)
        {
            var command = new Delete_Ticket_Command { delete_ticket = delete_ticket_dto};
            var response = await this.mediator.Send(command);
            return Ok(response);
        }
        
        [HttpGet]
        [Route("GetTickets")]
        public async Task<ActionResult> Get_Tickets()
        {
            var query = new Get_Tickets_Query() {};
            var response = await this.mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetTicket")]        
        public async Task<ActionResult> Get_Ticket_Details([FromQuery(Name = "id")] int id)
        {
            var query = new Get_Ticket_Details_Query() {id = id};
            var response = await this.mediator.Send(query);
            return Ok(response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}