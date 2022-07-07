using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;

namespace API.DTOs.TicketDtos
{
    public class Get_Ticket_List_Dto
    {
        public string title { get; set; }
        public Ticket_Type ticket_type { get; set;}
        public Ticket_Status ticket_status { get; set; }
        public DateTime created_date { get; set; }
    }
}