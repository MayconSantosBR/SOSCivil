using FluentResults;
using SosCivil.Api.Data.Entities.Base;

namespace SosCivil.Api.Services.Base.Interfaces
{
    public interface ISosCivilServiceBase<T> where T : BaseEntity
    {
        Task<Result<T>> MapAndCreateAsync<M>(M dto);
        Task<Result<T>> CreateAsync(T entity);
        Task<Result> CreateOrUpdateAsync();
        Task<Result<List<T>>> GetAllAsync();
        Task<Result<T>> GetByIdAsync(long id);
        Task<Result> RemoveAsync(long id);
        Task<Result> UpdateAsync(T entity);
    }
}