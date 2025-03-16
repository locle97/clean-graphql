namespace CleanGraphQL.Core.Settings;

public class MongoDbSetting
{
    public required string ConnectionString { get; set; }

    public string? DatabaseName { get; set; }

    public string? SwitchesCollectionName { get; set; }

    public string? BrandsCollectionName { get; set; }
}
