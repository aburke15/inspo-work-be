namespace InspoWork.Common.Models.Responses;

public class PostTypeResponseV1
{
    public string PostTypeId { get; init; } = string.Empty;
    public int Value { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}