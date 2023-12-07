using System.ComponentModel;

namespace SosCivil.Mvc.Models
{
    public class Documento
    {
        public long Id { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        public Solicitacao Solicitacao { get; set;}
        public string DownloadLink { get; set; }

    }
}
