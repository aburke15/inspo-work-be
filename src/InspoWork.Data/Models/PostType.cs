namespace InspoWork.Data.Models;

public sealed class PostType
{
    public int Id { get; set; }
    public int PostTypeValue { get; set; }
    public string? PostTypeName { get; set; }
    public string? Description { get; set; }
}