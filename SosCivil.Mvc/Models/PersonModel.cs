using SosCivil.Mvc.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SosCivil.Mvc.Models
{
    public class PersonModel
    {
        public string Name { get; set; }

        public TipoPessoaEnum PersonType { get; set; }

        [MinLength(11), MaxLength(14)]
        public string CpfCnpj { get; set; }

        [MaxLength(15)]
        public string Cellphone { get; set; }
    }
}
