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
        //Client sends request to one of the URLs listed below (Endpoint)
        //Controller receives information FromBody, Query, etc.
        //A command/query is created from the information and sent to a CommandHandler/QueryHandler via Mediator
        //A response object is passed from the handler back to the controller to return to client

        private readonly IMediator mediator;
        
        public TicketController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("CreateTicket")]
        // /api/CreateTicket
        public async Task<ActionResult<Create_Ticket_Command_Response>> Post([FromBody] Create_Ticket_Dto create_ticket_dto)
        {
            var command = new Create_Ticket_Command { ticket_dto = create_ticket_dto };
            var response = await this.mediator.Send(command);

            var note = response.note_response;
            var note_command = new Create_Ticket_Note_Command { ticket_note_dto = note};
            await this.mediator.Send(note_command);

            return Ok(response);
        }

        [HttpPost]
        [Route("CreateTicketNote")]
        // /api/CreateTicketNote
        public async Task<ActionResult<Create_Ticket_Note_Command_Response>> Post([FromBody] Create_Ticket_Note_Dto create_note)
        {
            var command = new Create_Ticket_Note_Command {ticket_note_dto = create_note};
            var response = await this.mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        [Route("DeleteTicket")]
        // /api/DeleteTicket
        public async Task<ActionResult<Base_Command_Response>> Delete_Ticket([FromBody] Delete_Ticket_Dto delete_ticket_dto)
        {
            var command = new Delete_Ticket_Command { delete_ticket = delete_ticket_dto};
            var response = await this.mediator.Send(command);
            return Ok(response);
        }
        
        [HttpGet]
        [Route("GetTickets")]
        // /api/GetTickets
        public async Task<ActionResult> Get_Tickets()
        {
            var query = new Get_Tickets_Query() {};
            var response = await this.mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetTicket")]        
        // /api/GetTicket
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