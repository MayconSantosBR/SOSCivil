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
        public UserService(IRepository<User> repository, IMapper mapper) : base(repository, mapper)
        {
            _mapper = mapper;
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

    }
}
