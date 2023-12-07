using AutoMapper;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Models.Dtos.Controllers;

namespace SosCivil.Api.Models.AutoMapper.Profiles
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<RequestDto, Request>()
                .ReverseMap();
        }
    }
}
