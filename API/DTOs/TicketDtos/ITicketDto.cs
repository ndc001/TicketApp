namespace API.DTOs.TicketDtos
{
    public interface ITicketDto
    {
        public string title { get; set; }
        public string ticket_description { get; set; }
        public int ticket_type { get; set; }
        public int created_by { get; set; }
    }
}