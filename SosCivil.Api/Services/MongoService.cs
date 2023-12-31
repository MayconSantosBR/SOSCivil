﻿using MongoDB.Driver;
using SosCivil.Api.Services.Interfaces;
using System.Linq.Expressions;

namespace SosCivil.Api.Services
{
    public class MongoService : IMongoService
    {
        private readonly IMongoClient _mongoClient;

        public MongoService(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        public async Task<T> GetOneAsync<T>(string collectionName, Expression<Func<T, bool>> filter)
        {
            return await GetCollection<T>(collectionName).Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync<T>(string collectionName, Expression<Func<T, bool>> filter)
        {
            return await GetCollection<T>(collectionName).Find(filter).ToListAsync();
        }

        public async Task<T> CreateAsync<T>(string collectionName, T entity)
        {
            await GetCollection<T>(collectionName).InsertOneAsync(entity);
            return entity;
        }

        public async Task<T> UpdateAsync<T>(string collectionName, Expression<Func<T, bool>> filter, UpdateDefinition<T> update)
        {
            return await GetCollection<T>(collectionName).FindOneAndUpdateAsync(filter, update);
        }

        public async Task<T> ReplaceAsync<T>(string collectionName, Expression<Func<T, bool>> filter, T entity)
        {
            return await GetCollection<T>(collectionName).FindOneAndReplaceAsync(filter, entity);
        }

        public async Task<T> DeleteAsync<T>(string collectionName, Expression<Func<T, bool>> filter)
        {
            return await GetCollection<T>(collectionName).FindOneAndDeleteAsync(filter);
        }

        private IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _mongoClient.GetDatabase("sos-civil").GetCollection<T>(collectionName);
        }
    }
}
