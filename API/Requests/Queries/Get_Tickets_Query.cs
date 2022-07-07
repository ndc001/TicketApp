using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.TicketDtos;
using MediatR;

namespace API.Requests.Queries
{
    public class Get_Tickets_Query : IRequest<List<Get_Ticket_List_Dto>>
    {
        
    }
}