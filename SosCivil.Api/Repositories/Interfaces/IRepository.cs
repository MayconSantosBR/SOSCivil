using SosCivil.Api.Data.Entities.Base;
using System.Linq.Expressions;

namespace SosCivil.Api.Repositories.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task CreateAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(long id);
        Task Update(TEntity entity);
        Task RemoveAsync(long id);
        Task<int> SaveChanges();
    }
}
