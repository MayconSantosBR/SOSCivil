using Newtonsoft.Json;
using SosCivil.Core.Data.Enums;

namespace SosCivil.Mvc.Models.Services
{
    public class SuprimentoDto
    {
        [JsonProperty("name")]
        public string Nome { get; set; }

        [JsonProperty("description")]
        public string Descricao { get; set; }

        [JsonProperty("unityOfMeasurement")]
        public UnityOfMeasurementEnum UnidadeDeMedida { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantidade { get; set; }

        [JsonProperty("totalQuantityWithUnity")]
        public decimal QuantidadeTotal { get; set; }
    }
}
