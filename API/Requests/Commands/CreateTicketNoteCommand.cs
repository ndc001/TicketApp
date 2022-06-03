using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.TicketNoteDtos;
using MediatR;

namespace API.Requests.Commands
{
    public class CreateTicketNoteCommand : IRequest<BaseCommandResponse>
    {
                public CreateTicketNoteDto TicketNoteDto { get; set; }

    }
}