using System.Text.Json.Serialization;

namespace SosCivil.Mvc.Models
{
    public class RequestItemModel
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("itemId")]
        public long ItemId { get; set; }
        [JsonPropertyName("quantity")]
        public decimal Quantity { get; set; }
    }
}
