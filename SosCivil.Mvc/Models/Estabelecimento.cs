using System.Text.Json.Serialization;

namespace SosCivil.Mvc.Models
{
    public class Estabelecimento
    {
        [JsonPropertyName("personId")]
        public long PersonId { get; set ; }
        [JsonPropertyName("street")]
        public string Street{ get; set; }
        [JsonPropertyName("neighborhood")]
        public string Neighborhood { get; set; }
        [JsonPropertyName("zipcode")]
        public string ZipCode { get; set; }
        [JsonPropertyName("id")]
        public long Id{ get; set; }
    }
}
