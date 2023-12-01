using AutoMapper;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Repositories.Interfaces;
using SosCivil.Api.Services.Base;
using SosCivil.Api.Services.Interfaces;

namespace SosCivil.Api.Services
{
    public class RequestItemService : SosCivilServiceBase<RequestItem>, IRequestItemService
    {
        private readonly IMapper _mapper;
        public RequestItemService(IRepository<RequestItem> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }
    }
}
