using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CleanGraphQL.Core.Entities;

public class Brand
{
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonId]
    public string? Id { get; set; }

    [BsonElement("name")]
    public string? Name { get; set; }
}
