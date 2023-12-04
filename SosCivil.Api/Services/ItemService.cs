using AutoMapper;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Repositories.Interfaces;
using SosCivil.Api.Services.Base;
using SosCivil.Api.Services.Interfaces;

namespace SosCivil.Api.Services
{
    public class ItemService : SosCivilServiceBase<Item>, IItemService
    {
        private readonly IMapper _mapper;
        public ItemService(IRepository<Item> repository, IMapper mapper) : base(repository, mapper)
        {
            _mapper = mapper;
        }
    }
}
