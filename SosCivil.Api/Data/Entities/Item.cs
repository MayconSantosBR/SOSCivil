using SosCivil.Api.Data.Entities.Base;

namespace SosCivil.Api.Data.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }

        //Precisa de mais informações
    }
}
