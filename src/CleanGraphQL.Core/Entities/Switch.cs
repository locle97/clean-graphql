using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CleanGraphQL.Core.Entities;

public class Switch
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public required string Id { get; set; }

    [BsonElement("name")]
    public string? Name { get; set; }

    [BsonElement("stem")]
    public string? Stem { get; set; }

    [BsonElement("type")]
    public string? Type { get; set; }

    [BsonElement("numberOfPins")]
    public int? NumberOfPins { get; set; }

    [BsonElement("force")]
    public float? Force { get; set; }

    [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
    [BsonElement("forceDeviation")]
    public float? ForceDeviation { get; set; }

    [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
    [BsonElement("bottomForce")]
    public float? BottomForce { get; set; }

    [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
    [BsonElement("bottomForceDiviation")]
    public float? BottomForceDiviation { get; set; }

    [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
    [BsonElement("preTravel")]
    public float? PreTravel { get; set; }

    [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
    [BsonElement("preTravelDeviation")]
    public float? PreTravelDeviation { get; set; }

    [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
    [BsonElement("totalTravel")]
    public float? TotalTravel { get; set; }

    [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
    [BsonElement("totalTravelDeviation")]
    public float? TotalTravelDeviation { get; set; }

    [BsonElement("image")]
    public string? Image { get; set; }

    public Brand? Brand { get; set; }

    [BsonElement("brandId")]
    public string? BrandId { get; set; }
}
