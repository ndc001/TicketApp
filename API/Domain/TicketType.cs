using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Domain
{
    public class TicketType : Enumeration
    {
         public TicketType(int type_id, string value) : base(type_id, value) 
        {            
        }

        public static TicketType Hardware = new(1, nameof(Hardware));
        public static TicketType Software = new(2, nameof(Software));
        
    }
}