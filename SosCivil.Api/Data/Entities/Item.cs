using SosCivil.Api.Data.Entities.Base;
using SosCivil.Core.Data.Enums;

namespace SosCivil.Api.Data.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public UnityOfMeasurementEnum UnityOfMeasurement { get; set; }
        public decimal QuantityWithUnit { get; set; }
    }
}
