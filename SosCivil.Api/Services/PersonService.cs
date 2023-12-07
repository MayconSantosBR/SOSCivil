using AutoMapper;
using FluentResults;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Models.Dtos.Controllers;
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

        public async Task<Person> CreateAndReturn(PersonDto personDto)
        {
            var entity = _mapper.Map<Person>(personDto);
            return await CreateAsync(entity);
        }

        public async Task<Person> CreateAsync(Person entity)
        {
                var person =  await _repository.CreateAsync(entity);
                return person;
        }
    }
}
