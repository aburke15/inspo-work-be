using InspoWork.Common.Models.Requests;
using InspoWork.Common.Models.Responses;

namespace InspoWork.Services.Posts;

public interface IPostService
{
    Task<PostResponseV1> CreatePostAsync(CreatePostRequestV1 post, CancellationToken ct = default);
    Task<IEnumerable<PostResponseV1>> GetAllPostsAsync(CancellationToken ct = default);
    Task<PostResponseV1?> GetPostByIdAsync(string id, CancellationToken ct = default);
    Task<PostTypeResponseV1?> GetPostTypeByValueAsync(int value, CancellationToken ct = default);
    Task<IEnumerable<PostTypeResponseV1>> GetAllPostTypesAsync(CancellationToken ct = default);
    Task<PostTypeResponseV1> CreatePostTypeAsync(CreatePostTypeRequestV1 request, CancellationToken ct);
}