using InspoWork.Common.Enums;

namespace InspoWork.Api.Requests;

public class CreatePostRequestV1
{
    public string? Title { get; set; } = default;
    public string? Body { get; set; } = default;
    public PostType PostType { get; set; } = PostType.None;
}