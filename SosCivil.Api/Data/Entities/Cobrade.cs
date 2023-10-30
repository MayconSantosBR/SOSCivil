using SosCivil.Api.Data.Entities.Base;

namespace SosCivil.Api.Data.Entities
{
    public class Cobrade : BaseEntity
    {
        public int CobradeCode { get; set; }
        public string CobradeType { get; set; }
        public string Description { get; set; }
    }   
}
