using SosCivil.Core.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace SosCivil.Api.Models.Dtos.Controllers
{
    public class PersonDto
    {
        public string Name { get; set; }

        public TipoPessoaEnum PersonType { get; set; }

        [MinLength(11), MaxLength(14)]
        public string CpfCnpj { get; set; }

        [MaxLength(15)]
        public string Cellphone { get; set; }
    }
}
