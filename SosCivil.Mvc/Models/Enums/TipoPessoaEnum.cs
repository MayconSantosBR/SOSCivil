using System.ComponentModel;

namespace SosCivil.Mvc.Models.Enums
{
    public enum TipoPessoaEnum
    {
        [Description("Pessoa física")]
        Fisica = 0,

        [Description("Pessoa jurídica")]
        Juridica = 1,

        [Description("Usuário padrão")]
        Usuario = 2,

    }
}
