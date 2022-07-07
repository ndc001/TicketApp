using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.DTOs.TicketDtos;
using API.Requests;
using API.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult<Base_Command_Response>> Post([FromBody] Create_Ticket_Dto create_ticket_dto)
        {
            var command = new Create_Ticket_Command { ticket_dto = create_ticket_dto };
            var response = await this.mediator.Send(command);
            return Ok(response);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}