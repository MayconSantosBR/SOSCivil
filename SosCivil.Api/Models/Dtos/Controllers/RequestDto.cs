using Newtonsoft.Json;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Data.Enums;
using System.Text.Json.Serialization;

namespace SosCivil.Api.Models.Dtos.Controllers
{
    public class RequestDto
    {
        [JsonProperty("occurrenceId")]
        public long OccurrenceId { get; set; }
        [JsonProperty("status")]
        public StatusEnum Status { get; set; }
        [JsonProperty("requestDate")]
        public DateTime RequestDate { get; set; }
        [JsonProperty("deliveryDate")]
        public DateTime? DeliveryDate { get; set; }
    }
}
