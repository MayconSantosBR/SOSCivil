using System.Text.Json.Serialization;

namespace SosCivil.Mvc.Models
{
    public class OcurrenceModel
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("personId")]
        public long PersonId { get; set; }
        [JsonPropertyName("establishmentId")]
        public long EstablishmentId { get; set; }
        [JsonPropertyName("userId")]
        public long UserId { get; set; }
        [JsonPropertyName("status")]
        public int Status { get; set; }
        [JsonPropertyName("requestItemId")]
        public long requestItemId { get; set; }
    }
}
