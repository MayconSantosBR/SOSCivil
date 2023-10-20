using Microsoft.EntityFrameworkCore;
using SosCivil.Api.Data.Contexts;
using SosCivil.Api.Data.Entities.Base;
using SosCivil.Api.Repositorys.Interfaces;
using System.Linq.Expressions;

namespace SosCivil.Api.Repositorys
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly MainContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(MainContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(long id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(long id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
