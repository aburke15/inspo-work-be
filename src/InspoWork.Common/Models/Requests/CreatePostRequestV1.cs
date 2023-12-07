using InspoWork.Common.Enums;

namespace InspoWork.Common.Models.Requests;

public class CreatePostRequestV1
{
    public string? Title { get; set; } = default;
    public string? Body { get; set; } = default;
    public CreatePostTypeRequestV1 PostType { get; set; } = null!;
}