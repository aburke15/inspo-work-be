namespace InspoWork.Common.Models.Responses;

public class PostTypeResponseV1
{
    public string Id { get; init; } = string.Empty;
    public string? PostTypeName { get; set; } = string.Empty;
    public int PostTypeValue { get; set; }
}