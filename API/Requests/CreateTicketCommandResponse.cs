using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;
using API.DTOs.TicketDtos;
using API.Requests;

namespace API
{
    public class CreateTicketCommandResponse : BaseCommandResponse
    {
        public TicketDto TicketResponse { get; set; }
    }
}