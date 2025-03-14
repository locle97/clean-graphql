using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CleanGraphQL.Core.Entities;

public class Switch
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string Id { get; set; }

    public string? Name { get; set; }

    public string? Stem { get; set; }

    public string? Type { get; set; }

    public int? NumberOfPins { get; set; }

    public float? Force { get; set; }

    public float? BottomForce { get; set; }

    public float? PreTravel { get; set; }

    public float? TotalTravel { get; set; }

    public string? Image { get; set; }

    public int? BrandId { get; set; }

    public Brand? Brand { get; set; }
}
