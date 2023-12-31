﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SosCivil.Mvc.Models.Auth
{
    public class UsuarioRegistroViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
        public string Senha { get; set; }

        [DisplayName("Confirme sua senha")]
        [Compare("Senha",ErrorMessage = "As senhas não conferem.")]
        public string SenhaConfirmacao{ get; set; }

        [MinLength(11), MaxLength(14)]
        public string CpfCnpj { get; set; }

        [MaxLength(15)]
        public string Cellphone { get; set; }

        public int PersonType { get; set; }
    }
}
