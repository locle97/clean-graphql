using CleanGraphQL.Core.Entities;
using CleanGraphQL.Core.Interfaces;
using CleanGraphQL.Core.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CleanGraphQL.Infrastructure.Presistence;

public class SwitchesRepository : ISwitchesRepository
{
    private readonly IMongoCollection<Switch> _switchesCollection;

    public SwitchesRepository(IOptions<MongoDbSetting> mongoDbSetting)
    {
        var mongoClient = new MongoClient(
            mongoDbSetting.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            mongoDbSetting.Value.DatabaseName);

        _switchesCollection = mongoDatabase.GetCollection<Switch>(
            mongoDbSetting.Value.SwitchesCollectionName);
    }

    public Task<Switch> Get(string id)
    {
        return _switchesCollection.Find(t => t.Id == id).FirstOrDefaultAsync();
    }

    public Task<List<Switch>> GetAll()
    {
        return _switchesCollection.Find(t => true).ToListAsync();
    }
}

