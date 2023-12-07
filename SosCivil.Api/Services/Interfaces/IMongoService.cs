namespace SosCivil.Api.Services.Interfaces
{
    public interface IMongoService
    {
        Task<T> CreateAsync<T>(string collectionName, T entity);
    }
}