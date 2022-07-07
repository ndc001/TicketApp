using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.TicketNoteDtos;

namespace API.Requests
{
    public class Create_Ticket_Note_Command_Response : Base_Command_Response
    {
        
        public Ticket_Note_Dto ticket_note_response { get; set; }
    }
    
}