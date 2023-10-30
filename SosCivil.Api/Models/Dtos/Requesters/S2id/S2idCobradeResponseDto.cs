using Newtonsoft.Json;

namespace SosCivil.Api.Models.Dtos.Requesters.S2id
{
    public class S2idCobradeResponseDto
    {
        [JsonProperty("cobrade")]
        public int CobradeCode { get; set; }

        [JsonProperty("tipo")]
        public string CobradeType { get; set; }

        [JsonProperty("descricao")]
        public string Description { get; set; }
    }
}
