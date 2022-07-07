using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;
using API.DTOs.TicketDtos;
using API.Requests;

namespace API
{
    public class Create_Ticket_Command_Response : Base_Command_Response
    {
        public Ticket_Dto ticket_response { get; set; }
    }
}