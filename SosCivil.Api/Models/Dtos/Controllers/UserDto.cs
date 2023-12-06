using System.ComponentModel.DataAnnotations;

namespace SosCivil.Api.Models.Dtos.Controllers
{
    public class UserDto
    {
        public long PersonId { get; set; }

        public string Username { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
