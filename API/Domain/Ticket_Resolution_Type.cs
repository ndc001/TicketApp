using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Domain
{
    public enum Ticket_Resolution_Type
    {
        none,
        resolved_by_caller,
        resolved_by_user,
        not_reproducible,
        closed_due_to_inactivity,
    }
}