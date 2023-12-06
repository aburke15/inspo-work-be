using InspoWork.Common.Models.Requests;
using InspoWork.Common.Models.Responses;
using InspoWork.Data.Models;

namespace InspoWork.Services.Mappings;

public static class PostMap
{
    public static PostType RequestToPostType(CreatePostTypeRequestV1 request)
    {
        return new PostType
        {
            Value = request.Value,
            Name = request.Name,
            Description = request.Description
        };
    }

    public static PostTypeResponseV1 PostTypeToResponse(PostType postType)
    {
        return new PostTypeResponseV1
        {
            PostTypeId = postType.PostTypeId.ToString()!,
            Value = postType.Value,
            Name = postType.Name,
            Description = postType.Description
        };
    }
}