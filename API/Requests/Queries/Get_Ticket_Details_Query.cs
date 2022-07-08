using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.TicketDtos;
using MediatR;

namespace API.Requests.Queries
{
    public class Get_Ticket_Details_Query : IRequest<Ticket_Dto>
    {
        public int id { get; set; }
    }
}