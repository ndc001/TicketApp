using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.TicketDtos;
using MediatR;

namespace API.Requests.Commands
{
    public class Delete_Ticket_Command : IRequest<Base_Command_Response>    
    {
        public Delete_Ticket_Dto delete_ticket { get; set; }
    }
}