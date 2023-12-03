using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SosCivil.Core.Data.Enums;

namespace SosCivil.Api.Models.Dtos.Controllers
{
    public class ItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public UnityOfMeasurementEnum UnityOfMeasurement { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalQuantityWithUnity { get; set; }
    }
}
