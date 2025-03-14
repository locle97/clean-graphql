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

    [BsonRepresentation(BsonType.Double, AllowTruncation=true)]
    public float? ForceDeviation { get; set; }

    [BsonRepresentation(BsonType.Double, AllowTruncation=true)]
    public float? BottomForce { get; set; }

    [BsonRepresentation(BsonType.Double, AllowTruncation=true)]
    public float? BottomForceDiviation { get; set; }

    [BsonRepresentation(BsonType.Double, AllowTruncation=true)]
    public float? PreTravel { get; set; }

    [BsonRepresentation(BsonType.Double, AllowTruncation=true)]
    public float? PreTravelDeviation { get; set; }

    [BsonRepresentation(BsonType.Double, AllowTruncation=true)]
    public float? TotalTravel { get; set; }

    [BsonRepresentation(BsonType.Double, AllowTruncation=true)]
    public float? TotalTravelDeviation { get; set; }

    public string? Image { get; set; }
}
