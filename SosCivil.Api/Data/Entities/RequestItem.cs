using SosCivil.Api.Data.Entities.Base;

namespace SosCivil.Api.Data.Entities
{
    public class RequestItem : BaseEntity
    {
        public long ItemId { get; set; }
        public Item Item { get; set; }
        public Occurrence Occurrence { get; set; }
        public int Quantity { get; set; }
    }
}
