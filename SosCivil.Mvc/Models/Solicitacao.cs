using SosCivil.Api.Data.Enums;

namespace SosCivil.Mvc.Models
{
    public class Solicitacao
    {
        public int Id { get; set; }
        public string NomeSolicitante { get; set; }
        public string CpfCnpjSolicitante { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public Suprimento Suprimento { get; set; }
    }
}
