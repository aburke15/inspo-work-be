using InspoWork.Common.Enums;

namespace InspoWork.Data.Models;

public class Post
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public PostType PostType { get; set; }
}