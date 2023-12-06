using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InspoWork.Data.Models;

public sealed class PostType
{
    [BsonElement("_id")]
    public ObjectId PostTypeId { get; set; }
    public int Value { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}