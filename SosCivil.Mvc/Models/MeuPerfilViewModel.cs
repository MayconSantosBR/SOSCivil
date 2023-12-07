using System.Text.Json.Serialization;

namespace SosCivil.Mvc.Models
{
    public class MeuPerfilViewModel
    {
        [JsonPropertyName("username")] 
        public string Nome { get; set; }

        [JsonPropertyName("email")] 
        public string Email { get; set; }

        
        [JsonPropertyName("person")] 
        public PessoaViewModel Pessoa { get; set; }

        [JsonPropertyName("password")] 
        public string Senha { get; set; }
    }

    public class PessoaViewModel
    {
        [JsonPropertyName("cpfCnpj")] 
        public string Documento { get; set; }

        [JsonPropertyName("cellphone")]
        public string Telefone { get; set; }
    }
}
