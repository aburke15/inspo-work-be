using InspoWork.Common.Models.Requests;
using InspoWork.Common.Models.Responses;

namespace InspoWork.Services.Posts;

public interface IPostService
{
    Task<PostResponseV1> CreatePostAsync(CreatePostRequestV1 post, CancellationToken ct = default);
    Task<IEnumerable<PostResponseV1>> GetAllPostsAsync(CancellationToken ct = default);
    Task<PostResponseV1?> GetPostByIdAsync(string id, CancellationToken ct = default);
    Task<PostTypeResponseV1?> GetPostTypeByValue(int value, CancellationToken ct = default);
}