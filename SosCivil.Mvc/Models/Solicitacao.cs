using SosCivil.Api.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SosCivil.Mvc.Models
{
    public class Solicitacao
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        public string NomeSolicitante { get; set; }
        [MinLength(11), MaxLength(14)]
        public string CpfCnpjSolicitante { get; set; }
        [MaxLength(15)]
        public string Celular { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        [MaxLength(8)]
        public string Cep { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public Suprimento Suprimento { get; set; }
    }
}
