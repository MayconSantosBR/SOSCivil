using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SosCivil.Core.Data.Enums
{
    public enum TipoPessoaEnum
    {
        [Description("Pessoa física")]
        Fisica = 0,

        [Description("Pessoa jurídica")]
        Juridica = 1,

        [Description("Usuário padrão")]
        Usuario = 2,

        [Description("Administrador")]
        Administrador = 3
    }
}
