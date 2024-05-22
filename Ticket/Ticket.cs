using System.ComponentModel.DataAnnotations;

namespace Ticket
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public string? Name => $"{TypeOfTicket}{Id}";
        public required string Description { get; set; }
        public required string Title { get; set; }
        public required TicketType TypeOfTicket { get; set; }
        public enum TicketType
        {
            IN, //Internal
            CS, //Customer
            GE, //General
        }

    }
}
