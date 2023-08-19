using SosCivil.Core.Data.Enums;

namespace SosCivil.Api.Data.Entities
{
    public class Person
    {
        public string Name { get; set; }
        public TipoPessoaEnum PersonType { get; set; }
        public string CpfCnpj { get; set; }
        public string Cellphone { get; set; }
    }
}
