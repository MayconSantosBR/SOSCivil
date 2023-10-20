using SosCivil.Api.Data.Entities.Base;

namespace SosCivil.Api.Repositorys.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(long id);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task Remover(long id);
        Task<int> SaveChanges();
    }
}
