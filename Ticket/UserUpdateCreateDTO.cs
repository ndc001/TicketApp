using System.ComponentModel.DataAnnotations;

namespace Ticket
{
    public class UserUpdateCreateDTO
    {
        [Required]
        public required string userName { get; set; }

        [Required]
        public required string password { get; set; }

        [Required]
        public required string email { get; set; }

        [Required]
        public bool isNewUser { get; set; }
    }
}
