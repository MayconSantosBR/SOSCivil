using AutoMapper;
using SosCivil.Mvc.Models.Services;

namespace SosCivil.Mvc.Models.AutoMapper.Profiles
{
    public class SuprimentoProfile : Profile
    {
        public SuprimentoProfile()
        {
            CreateMap<Suprimento, SuprimentoDto>()
                .ReverseMap();
        }
    }
}
