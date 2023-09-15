using SosCivil.Api.Data.Entities.Base;

namespace SosCivil.Api.Data.Entities
{
    public class Establishment : BaseEntity
    {
        public long PersonId { get; set; }
        public Person Person { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public ICollection<Occurrence> Occurrences { get; set; }
    }
}
