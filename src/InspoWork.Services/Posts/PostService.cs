using InspoWork.Common.Mappings;
using InspoWork.Common.Models.Requests;
using InspoWork.Common.Models.Responses;
using InspoWork.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace InspoWork.Services.Posts;

public class PostService : IPostService
{
    private readonly InspoWorkDbContext _inspoWorkDbContext;
    
    public PostService(InspoWorkDbContext inspoWorkDbContext)
    {
        _inspoWorkDbContext = inspoWorkDbContext;
    }
    
    public async Task<PostResponseV1> CreatePostAsync(CreatePostRequestV1 request, CancellationToken ct = default)
    {
        try
        {
            var entity = PostMap.RequestToPost(request);
            var post = _inspoWorkDbContext.Posts.Add(entity);
            await _inspoWorkDbContext.SaveChangesAsync(ct);

            return PostMap.PostToResponse(post.Entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<PostResponseV1>> GetAllPostsAsync(CancellationToken ct = default)
    {
        await Task.Delay(100, ct);
        throw new NotImplementedException();
    }

    public async Task<PostResponseV1?> GetPostByIdAsync(string id, CancellationToken ct = default)
    {
        var post = await _inspoWorkDbContext.Posts
            .Include(post => post.PostType)
            .SingleOrDefaultAsync(p => p.Id == new ObjectId(id), ct);

        return post is null ? null : PostMap.PostToResponse(post);
    }

    public async Task<PostTypeResponseV1?> GetPostTypeByValueAsync(int value, CancellationToken ct = default)
    {
        await Task.Delay(100, ct);
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<PostTypeResponseV1>> GetAllPostTypesAsync(CancellationToken ct = default)
    {
        await Task.Delay(100, ct);
        throw new NotImplementedException();
    }

    public async Task<PostTypeResponseV1> CreatePostTypeAsync(CreatePostTypeRequestV1 request, CancellationToken ct)
    {
        await Task.Delay(100, ct);
        throw new NotImplementedException();
    }
}