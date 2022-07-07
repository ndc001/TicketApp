using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;
using API.DTOs.TicketNoteDtos;

namespace API.DTOs.TicketDtos
{
    public class Ticket_Dto
    {
        public int ticket_id { get; set; }
        public Ticket_Type ticket_type { get; set; }        
        public Ticket_Status ticket_status { get; set; }
        public DateTime created_date { get; set; }       
        public string title { get; set; }
        public string ticket_description { get; set; }        
        public DateTime assigned_date { get; set; }        
        public DateTime resolved_date { get; set; }
        public Ticket_Resolution_Type ticket_resolution_type { get; set; }
        public string resolution_note { get; set; }
        public ICollection<Ticket_Note_Dto> ticket_notes { get; set; }

        //public int assigned_to { get; set; }
        //public int resolved_by { get; set; }
        //public int created_by { get; set; }
    }
}