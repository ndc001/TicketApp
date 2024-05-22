using System.ComponentModel.DataAnnotations;

namespace Ticket
{
    public class TicketUpdateCreateDTO
    {
        public string? name { get; set; }

        [Required]
        public string description { get; set; } = string.Empty;
        [Required]
        public string title { get; set; } = string.Empty;
        [Required]
        public bool isNewTicket { get; set; }

        [Required]
        public Ticket.TicketType typeOfTicket { get; set; }

    }
}
