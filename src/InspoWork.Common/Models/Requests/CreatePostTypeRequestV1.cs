namespace InspoWork.Common.Models.Requests;

public class CreatePostTypeRequestV1
{
    public int Value { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}