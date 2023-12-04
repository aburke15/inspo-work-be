namespace InspoWork.Common.Models.Responses;

public class PostResponseV1
{
    public string Id { get; set; } = string.Empty;
    public string? Title { get; set; }
    public string? Body { get; set; }
    public PostTypeResponseV1? PostType { get; set; }
}