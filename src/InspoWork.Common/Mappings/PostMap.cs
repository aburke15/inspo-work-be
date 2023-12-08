using InspoWork.Common.Models.Requests;
using InspoWork.Common.Models.Responses;
using InspoWork.Data.Models;

namespace InspoWork.Common.Mappings;

public static class PostMap
{
    public static Post RequestToPost(CreatePostRequestV1 request)
    {
        return new Post
        {
            Title = request.Title,
            Body = request.Body,
            PostType = RequestToPostType(request.PostType)
        };
    }

    public static PostResponseV1 PostToResponse(Post post)
    {
        return new PostResponseV1
        {
            Id = $"{post.Id}",
            Title = post.Title,
            Body = post.Body,
            PostType = PostTypeToResponse(post.PostType)
        };
    }

    private static PostType RequestToPostType(CreatePostTypeRequestV1 request)
    {
        return new PostType
        {
            Value = request.Value,
            Name = request.Name,
            Description = request.Description
        };
    }

    private static PostTypeResponseV1 PostTypeToResponse(PostType postType)
    {
        return new PostTypeResponseV1
        {
            Value = postType.Value,
            Name = postType.Name,
            Description = postType.Description
        };
    }
}