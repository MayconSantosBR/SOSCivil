using MongoDB.Driver;
using SosCivil.Api.Services.Interfaces;

namespace SosCivil.Api.Services
{
    public class MongoService : IMongoService
    {
        private readonly IMongoClient _mongoClient;

        public MongoService(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        private IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _mongoClient.GetDatabase("sos-civil").GetCollection<T>(collectionName);
        }
    }
}
