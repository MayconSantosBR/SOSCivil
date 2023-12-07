using MongoDB.Driver;
using System.Linq.Expressions;

namespace SosCivil.Api.Services.Interfaces
{
    public interface IMongoService
    {
        Task<T> GetOneAsync<T>(string collectionName, Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsync<T>(string collectionName, Expression<Func<T, bool>> filter);
        Task<T> CreateAsync<T>(string collectionName, T entity);
        Task<T> UpdateAsync<T>(string collectionName, Expression<Func<T, bool>> filter, UpdateDefinition<T> update);
        Task<T> DeleteAsync<T>(string collectionName, Expression<Func<T, bool>> filter);
        Task<T> ReplaceAsync<T>(string collectionName, Expression<Func<T, bool>> filter, T entity);
    }
}