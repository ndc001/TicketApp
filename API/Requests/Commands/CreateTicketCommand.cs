using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.DTOs.TicketDtos;
using MediatR;

namespace API.Requests.Commands
{
    public class CreateTicketCommand : IRequest<BaseCommandResponse>
    {
        public CreateTicketDto TicketDto { get; set; }
    }
}