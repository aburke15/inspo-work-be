using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InspoWork.Data.Models;

public sealed class PostType
{
    [BsonElement("_id")]
    public ObjectId Id { get; set; }
    public int PostTypeValue { get; set; }
    public string? PostTypeName { get; set; }
    public string? Description { get; set; }
}