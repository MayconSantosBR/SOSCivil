using SosCivil.Api.Data.Entities.Base;
using SosCivil.Api.Data.Enums;

namespace SosCivil.Api.Data.Entities
{
    public class Request : BaseEntity
    {
        public long OccurrenceId { get; set; }
        public Occurrence Occurrence { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}
