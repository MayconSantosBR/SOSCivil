using SosCivil.Api.Data.Enums;
using SosCivil.Core.Data.Enums;
using SosCivil.Mvc.Controllers;

namespace SosCivil.Mvc.Models
{
    public class Suprimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public UnityOfMeasurementEnum UnidadeDeMedida { get; set; }
        public decimal Quantidade { get; set; }
        public decimal QuantidadeTotal { get; set; }
    }
}
