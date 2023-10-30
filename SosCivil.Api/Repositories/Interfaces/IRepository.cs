using SosCivil.Api.Data.Entities.Base;
using System.Linq.Expressions;

namespace SosCivil.Api.Repositories.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task Create(TEntity entity);
        Task<List<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetById(long id);
        Task Update(TEntity entity);
        Task Remove(long id);
        Task<int> SaveChanges();
    }
}
