namespace InspoWork.Data.Models;

public sealed class Post
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public int PostTypeId { get; set; }
    
    public PostType? PostType { get; set; }
}