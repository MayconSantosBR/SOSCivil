using FluentResults;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Models.Dtos.Controllers;
using SosCivil.Api.Services.Base.Interfaces;

namespace SosCivil.Api.Services.Interfaces
{
    public interface IUserService : ISosCivilServiceBase<User>
    {
        Task<Result<User>> CreateAsync(UserDto dto, string email, Person person);
    }
}