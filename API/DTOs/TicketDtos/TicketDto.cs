using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;
using API.DTOs.TicketNoteDtos;

namespace API.DTOs.TicketDtos
{
    public class TicketDto
    {
        public int ticket_id { get; set; }
        public int ticket_type { get; set; }
        public TicketType TicketType { get; set; }        
        public int ticket_status { get; set; }
        public TicketStatus TicketStatus { get; set; }
        public DateTime created_date { get; set; }
        public int created_by { get; set; }
        public string title { get; set; }
        public string ticket_description { get; set; }
        public int assigned_to { get; set; }
        public DateTime assigned_date { get; set; }
        public int resolved_by { get; set; }
        public DateTime resolved_date { get; set; }

        public TicketResolutionType TicketResolutionType { get; set; }
        public int resolution_type { get; set; }
        public string resolution_note { get; set; }
        public ICollection<TicketNoteDto> TicketNotes { get; set; }
    }
}