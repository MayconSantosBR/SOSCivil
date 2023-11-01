using FluentResults;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Repositories.Interfaces;
using SosCivil.Api.Services.Interfaces;

namespace SosCivil.Api.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _personRepository;
        public PersonService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<Result<Person>> Get(long id)
        {
            try
            {
                return Result.Ok(await _personRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public async Task<Result<List<Person>>> GetAll()
        {
            try
            {
                return Result.Ok(await _personRepository.GetAll());
            }
            catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }
}
