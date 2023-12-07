using Newtonsoft.Json;
using SosCivil.Api.Data.Enums;
using SosCivil.Core.Data.Enums;
using SosCivil.Mvc.Controllers;

namespace SosCivil.Mvc.Models
{
    public class Suprimento
    {
        [JsonProperty("id")]
        public long Id { get; set; }

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
