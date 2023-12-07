using SosCivil.Api.Data.Entities.Base;
using SosCivil.Api.Data.Enums;

namespace SosCivil.Api.Data.Entities
{
    public class Occurrence : BaseEntity
    {
        public long PersonId { get; set; }
        public Person Person { get; set; }
        public long EstablishmentId { get; set; }
        public Establishment Establishment { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public StatusEnum Status { get; set; }
        public long RequestItemId { get; set; }
        public ICollection<RequestItem> RequestItem { get; set; }
    }
}
