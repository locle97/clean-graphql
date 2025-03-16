using CleanGraphQL.Core.Entities;
using CleanGraphQL.Core.Interfaces;
using CleanGraphQL.Core.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CleanGraphQL.Infrastructure.Presistence;

public class BrandsRepository : IBrandsRepository
{
    private readonly IMongoCollection<Brand> _switchesCollection;

    public BrandsRepository(IOptions<MongoDbSetting> mongoDbSetting)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(mongoDbSetting.Value.ConnectionString);

        var settings = MongoClientSettings.FromConnectionString(mongoDbSetting.Value.ConnectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);

        var mongoClient = new MongoClient(settings);

        var mongoDatabase = mongoClient.GetDatabase(
            mongoDbSetting.Value.DatabaseName);

        _switchesCollection = mongoDatabase.GetCollection<Brand>(
            mongoDbSetting.Value.BrandsCollectionName);
    }

    public Task<Brand> Get(string id)
    {
        return _switchesCollection.Find(t => t.Id == id).FirstOrDefaultAsync();
    }

    public IQueryable<Brand> GetAll()
    {
        try
        {
            var query = _switchesCollection.AsQueryable();
            return query;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}

