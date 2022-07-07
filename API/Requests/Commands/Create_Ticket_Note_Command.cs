using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.TicketNoteDtos;
using MediatR;

namespace API.Requests.Commands
{
    public class Create_Ticket_Note_Command : IRequest<Create_Ticket_Note_Command_Response>
    {
        public Create_Ticket_Note_Dto ticket_note_dto { get; set; }

    }
}