using AutoMapper;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Data.Entities.Mongo;
using SosCivil.Api.Models.Dtos.Controllers;

namespace SosCivil.Api.Models.AutoMapper.Profiles
{
    public class OccurrenceProfile : Profile
    {
        public OccurrenceProfile()
        {
            CreateMap<OccurrenceDto, Occurrence>()
                .ReverseMap();

            CreateMap<Occurrence, OccurrenceRegister>()
                .ForMember(dst => dst.OccurrenceId, src => src.MapFrom(c => c.Id))
                .ReverseMap();
        }
    }
}
