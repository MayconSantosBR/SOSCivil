using AutoMapper;
using FluentResults;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Models.Dtos.Controllers;
using SosCivil.Api.Repositories.Interfaces;
using SosCivil.Api.Services.Base;
using SosCivil.Api.Services.Interfaces;

namespace SosCivil.Api.Services
{
    public class UserService : SosCivilServiceBase<User>, IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Person> _personRepository;
        public UserService(IRepository<User> repository, IMapper mapper, IRepository<Person> personRepository) : base(repository, mapper)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public async Task<Result<User>> CreateAsync(UserDto dto, string email, Person person)
        {
            try
            {
                var entity = _mapper.Map<User>(dto);
                entity.Email = email;
                entity.Person = person;
                return await CreateAsync(entity);
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }


        public async Task<Result<User>> CreateAsync(User user)
        {
            try
            {
                await _repository.CreateAsync(user);
                return Result.Ok();
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }

        public async Task<Result<User>> GetByEmail(string email)
        {
            try
            {
                var user = await _repository.GetFirstOrDefault(c => c.Email == email);
                user.Person = await _personRepository.GetByIdAsync(user.PersonId);
                return Result.Ok(user);
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }
    }
}
