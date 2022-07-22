using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Domain
{
    public class Ticket_Note
    {
        public int ticket_note_id { get; set; }        
        public DateTime created_date { get; set; }
        public string? note_text { get; set; }
        public bool is_history_note { get; set; }
        public bool is_internal { get; set; }
        
        public int fk_ticket_id { get; set; }
        public virtual Ticket ticket { get; set;}

    }
}