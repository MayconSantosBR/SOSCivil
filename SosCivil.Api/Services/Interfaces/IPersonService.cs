using FluentResults;
using SosCivil.Api.Data.Entities;

namespace SosCivil.Api.Services.Interfaces
{
    public interface IPersonService
    {
        Task<Result<List<Person>>> GetAll();
        Task<Result<Person>> Get(long id);
    }
}
