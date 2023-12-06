using SosCivil.Api.Data.Entities;
using SosCivil.Api.Data.Enums;

namespace SosCivil.Api.Models.Dtos.Controllers
{
    public class RequestDto
    {
        public long OccurrenceId { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}
