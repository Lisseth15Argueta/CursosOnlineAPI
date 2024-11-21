using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.DbConnection
{
    public class GenericCRUDRepository : IGenericCRUDRepository
    {
        private readonly string _connectionURL;
        private readonly IMongoDatabase _database;
        private readonly IConfiguration _configuration;

        public GenericCRUDRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionURL = _configuration["MongoDbSettings:ConnectionURl"];
            var cliente = new MongoClient(_connectionURL);
            _database = cliente.GetDatabase(_configuration["MongoDbSettings:DatabaseName"]);
        }

        public async Task InsertAsync<T>(string table, T record)
        {
            var collection = _database.GetCollection<T>(table);
            await collection.InsertOneAsync(record);
        }
        public async Task<List<T>> GetAllAsync<T>(string table)
        {
            var collection = _database.GetCollection<T>(table);
            return await collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(string table, string id)
        {
            var collection = _database.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
            return await collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task DeleteAsync<T>(string table, string id)
        {
            var collection = _database.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
            await collection.DeleteOneAsync(filter);
        }

        public async Task UpsertAsync<T>(string table, T record, string id)
        {
            var collection = _database.GetCollection<T>(table);

            await collection.ReplaceOneAsync(
                    new BsonDocument("_id", new ObjectId(id)),
                    record,
                    new ReplaceOptions { IsUpsert = true }
            );

        }
    }
}
