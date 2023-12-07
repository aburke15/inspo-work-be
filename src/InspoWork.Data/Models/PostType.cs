using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InspoWork.Data.Models;

public sealed class PostType
{
    public int Value { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}