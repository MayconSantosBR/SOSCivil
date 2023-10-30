using AutoMapper;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Models.Dtos.Requesters.S2id;

namespace SosCivil.Api.Models.AutoMapper.Profiles
{
    public class CobradeProfile : Profile
    {
        public CobradeProfile()
        {
            CreateMap<S2idCobradeResponseDto, Cobrade>()
                .ForMember(c => c.Id, c => c.Ignore())
                .ForMember(c => c.CobradeCode, c => c.MapFrom(s => s.CobradeCode))
                .ForMember(c => c.CobradeType, c => c.MapFrom(s => s.CobradeType))
                .ForMember(c => c.Description, c => c.MapFrom(s => s.Description))
                .ReverseMap();
        }
    }
}
