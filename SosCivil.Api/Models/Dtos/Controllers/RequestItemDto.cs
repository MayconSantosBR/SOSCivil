using SosCivil.Api.Data.Entities;

namespace SosCivil.Api.Models.Dtos.Controllers
{
    public class RequestItemDto
    {
        public long ItemId { get; set; }
        public long OccurrenceId { get; set; }
        public int Quantity { get; set; }
    }
}
