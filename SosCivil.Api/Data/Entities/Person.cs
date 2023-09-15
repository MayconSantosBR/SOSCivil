using SosCivil.Core.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace SosCivil.Api.Data.Entities
{
    public class Person
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public TipoPessoaEnum PersonType { get; set; }

        [MinLength(11), MaxLength(14)]
        public string CpfCnpj { get; set; }

        [MaxLength(15)]
        public string Cellphone { get; set; }

        public ICollection<Establishment> Establishments { get; set; }
        public ICollection<Occurrence> Occurrences { get; set; }

    }
}
