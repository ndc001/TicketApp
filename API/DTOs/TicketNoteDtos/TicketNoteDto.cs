using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.TicketNoteDtos
{
    public class TicketNoteDto
    {
        public int ticket_note_id { get; set; }
        public int ticket_id { get; set; }
        public DateTime created_date { get; set; }
        public int created_by { get; set; }
        public string note_text { get; set; }
        public bool is_history_note { get; set; }
        public bool is_internal { get; set; }
    }
}