﻿using Newtonsoft.Json;
using SosCivil.Api.Data.Enums;

namespace SosCivil.Mvc.Models
{
    public class Entrega
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("occurrence")]
        public Solicitacao Solicitacao { get; set; }
        [JsonProperty("status")]
        public StatusEnum Status { get; set; }
        [JsonProperty("deliveryDate")]
        public DateTime DataEntrega { get; set; }
    }
}
