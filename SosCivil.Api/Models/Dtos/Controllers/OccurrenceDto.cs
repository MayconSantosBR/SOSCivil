using SosCivil.Api.Data.Entities.Mongo;
using SosCivil.Api.Data.Enums;

namespace SosCivil.Api.Models.Dtos.Controllers
{
    public class OccurrenceDto
    {
        public long PersonId { get; set; }
        public long EstablishmentId { get; set; }
        public long RequestItemId { get; set; }
        public long UserId { get; set; }
        public StatusEnum Status { get; set; }
        public List<OccurrenceDocuments>? Documents { get; set; }
    }
}
