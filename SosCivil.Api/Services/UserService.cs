using AutoMapper;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Repositories.Interfaces;
using SosCivil.Api.Services.Base;

namespace SosCivil.Api.Services
{
    public class UserService : SosCivilServiceBase<User>, IUserService
    {
        private readonly IMapper _mapper;
        public UserService(IRepository<User> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }
    }
}
