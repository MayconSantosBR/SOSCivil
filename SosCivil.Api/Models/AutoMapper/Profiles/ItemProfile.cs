using AutoMapper;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Models.Dtos.Controllers;

namespace SosCivil.Api.Models.AutoMapper.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemDto, Item>()
                .ReverseMap();
        }
    }
}
