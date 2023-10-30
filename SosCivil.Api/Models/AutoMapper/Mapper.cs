using AutoMapper;
using SosCivil.Api.Models.AutoMapper.Profiles;

namespace SosCivil.Api.Models.AutoMapper
{
    public class Mapper
    {
        public Mapper()
        {
            MapperConfiguration configuration = new(cfg =>
            {
                cfg.AddProfile<CobradeProfile>();
            });

            configuration.CreateMapper();
        }
    }
}
