namespace InspoWork.Common.Models.Responses;

public class PostResponseV1
{
    public string Id { get; init; } = null!;
    public string? Title { get; set; }
    public string? Body { get; set; }
    public PostTypeResponseV1? PostType { get; set; }
}