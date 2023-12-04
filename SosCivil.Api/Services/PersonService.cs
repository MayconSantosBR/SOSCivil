using AutoMapper;
using FluentResults;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Repositories.Interfaces;
using SosCivil.Api.Services.Base;
using SosCivil.Api.Services.Interfaces;

namespace SosCivil.Api.Services
{
    public class PersonService : SosCivilServiceBase<Person>, IPersonService
    {
        private readonly IMapper _mapper;
        public PersonService(IRepository<Person> repository, IMapper mapper) : base(repository, mapper)
        {
            _mapper = mapper;
        }
    }
}
