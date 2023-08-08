namespace InspoWork.Api.Responses;

public class PostResponseV1
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public PostTypeResponseV1? PostType { get; set; }
}