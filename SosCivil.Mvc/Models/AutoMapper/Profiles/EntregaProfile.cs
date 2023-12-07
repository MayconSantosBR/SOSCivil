using AutoMapper;
using SosCivil.Mvc.Models.Services;

namespace SosCivil.Mvc.Models.AutoMapper.Profiles
{
    public class EntregaProfile : Profile
    {
        public EntregaProfile()
        {
            CreateMap<Entrega, EntregaDto>()
                .ReverseMap();
        }
    }
}
