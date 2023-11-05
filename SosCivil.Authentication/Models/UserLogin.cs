using System.ComponentModel.DataAnnotations;

namespace SosCivil.Authentication.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} carácteres", MinimumLength = 6)]
        public string Senha { get; set; }
    }
}
