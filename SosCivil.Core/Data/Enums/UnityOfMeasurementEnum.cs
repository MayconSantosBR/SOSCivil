using System.ComponentModel;

namespace SosCivil.Core.Data.Enums
{
    public enum UnityOfMeasurementEnum
    {
        [Description("Metros")]
        Meters = 0,
        [Description("Centrimetros")]
        Centimeters = 1,
        [Description("Litros")]
        Liters = 2,
        [Description("Mililitro")]
        Milliliter = 3,
        [Description("Kilogramas")]
        Kilograms = 4,
        [Description("Gramas")]
        Grams = 5,
        [Description("Unidade")]
        Unit = 6
    }
}
