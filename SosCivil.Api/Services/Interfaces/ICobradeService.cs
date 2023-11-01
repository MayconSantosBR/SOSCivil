using FluentResults;
using SosCivil.Api.Data.Entities;

namespace SosCivil.Api.Services.Interfaces
{
    public interface ICobradeService
    {
        Task<Result<List<Cobrade>>> AllAsync();
        Task<Result> CreateOrUpdateCobradeAsync();
    }
}