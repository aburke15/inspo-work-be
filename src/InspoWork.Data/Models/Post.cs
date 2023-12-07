using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InspoWork.Data.Models;

public class Post
{
    [BsonElement("_id")]
    public ObjectId Id { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public PostType PostType { get; set; } = null!;
}