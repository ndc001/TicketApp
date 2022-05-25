using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Domain
{
    public class TicketStatus : Enumeration
    {
        /*public int status_id { get; set; }
        public string value { get; set; }*/

        public TicketStatus(int status_id, string value) : base(status_id, value) 
        {            
        }

        public static TicketStatus New = new(1, nameof(New));
        public static TicketStatus WorkInProgress = new(2, nameof(WorkInProgress));
        public static TicketStatus Closed = new(3, nameof(Closed));

    }
}