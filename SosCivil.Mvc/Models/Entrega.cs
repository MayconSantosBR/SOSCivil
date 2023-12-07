using SosCivil.Api.Data.Enums;

namespace SosCivil.Mvc.Models
{
    public class Entrega
    {
        public int Id { get; set; }
        public Solicitacao Solicitacao { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime DataEntrega { get; set; }
    }
}
