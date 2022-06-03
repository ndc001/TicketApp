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
        private readonly IMediator _mediator;
        
        public TicketController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTicketDto ticketDto)
        {
            var command = new CreateTicketCommand { TicketDto = ticketDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}