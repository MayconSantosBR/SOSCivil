using AutoMapper;
using SosCivil.Mvc.Models.AutoMapper.Profiles;

namespace SosCivil.Mvc.Models.AutoMapper
{
    public class Mapper
    {
        public Mapper()
        {
            MapperConfiguration configuration = new(cfg =>
            {
                cfg.AddProfile<SuprimentoProfile>();
            });

            configuration.CreateMapper();
        }
    }
}
