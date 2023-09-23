using System.ComponentModel.DataAnnotations;
using SosCivil.Api.Data.Entities.Base;

namespace SosCivil.Api.Data.Entities
{
    public class User : BaseEntity
    {
        public long PersonId { get; set; }
        public Person Person { get; set; }

        public string Username { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        public string Password { get; set; }
        public ICollection<Occurrence> Occurrences { get; set; }
    }
}
