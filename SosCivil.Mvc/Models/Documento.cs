using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SosCivil.Mvc.Models
{
    public class Documento
    {
        public long Id { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        public Solicitacao Solicitacao { get; set;}
        public string DownloadLink { get; set; }
        public string FileName { get; set; }

        public IFormFile File { get; set; }

    }

    public class DocumentoResponse
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
