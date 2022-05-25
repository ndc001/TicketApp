using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Domain
{
    public class TicketResolutionType : Enumeration
    {
        public TicketResolutionType(int resolution_type_id, string value) : base(resolution_type_id, value) 
        {            
        }

        public static TicketResolutionType ResolvedByUser = new(1, nameof(ResolvedByUser));
        public static TicketResolutionType ResolvedByCaller = new(2, nameof(ResolvedByCaller));
        public static TicketResolutionType NotReproducible = new(3, nameof(NotReproducible));
        public static TicketResolutionType ClosedDueToInactivity = new(4, nameof(ClosedDueToInactivity));

        
    }
}