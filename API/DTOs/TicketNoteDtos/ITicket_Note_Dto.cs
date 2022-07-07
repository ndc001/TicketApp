using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.TicketNoteDtos
{
    public interface ITicket_Note_Dto
    {
        
        public int ticket_id { get; set; }
        //public int created_by { get; set; }
        public string note_text { get; set; }
    }
}