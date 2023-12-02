using InspoWork.Data.Models;

namespace InspoWork.Api.Services;

public interface IPostService
{
    Task<Post> CreatePostAsync(Post post, CancellationToken ct = default);
    Task<IEnumerable<Post>> GetAllPostsAsync(CancellationToken ct = default);
    Task<Post?> GetPostByIdAsync(int id, CancellationToken ct = default);
    Task<PostType?> GetPostTypeByValue(int value, CancellationToken ct = default);
}