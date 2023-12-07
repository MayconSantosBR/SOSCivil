using SosCivil.Api.Data.Enums;
using System.Text.Json.Serialization;

namespace SosCivil.Mvc.Models
{
    public class SolicitacaoDto
    {
        [JsonPropertyName("occurreceId")]
        public long OccurrenceId { get; set; }
        [JsonPropertyName("status")]    
        public StatusEnum Status { get; set; }
        [JsonPropertyName("requestDate")]
        public DateTime RequestDate { get; set; }
        [JsonPropertyName("deliveryDate")]
        public DateTime? DeliveryDate { get; set; }
    } 
}
