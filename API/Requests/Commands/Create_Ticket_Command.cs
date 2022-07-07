using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.DTOs.TicketDtos;
using MediatR;

namespace API.Requests.Commands
{
    public class Create_Ticket_Command : IRequest<Base_Command_Response>
    {
        public Create_Ticket_Dto ticket_dto { get; set; }
    }
}