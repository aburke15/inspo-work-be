using Amazon.Runtime.Internal.Auth;
using InspoWork.Common.Models.Requests;
using InspoWork.Common.Models.Responses;
using InspoWork.Data;
using InspoWork.Data.Models;
using InspoWork.Services.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace InspoWork.Services.Posts;

public class PostService : IPostService
{
    private readonly InspoWorkDbContext _inspoWorkDbContext;
    private readonly ILogger<PostService> _logger;
    
    public PostService(InspoWorkDbContext inspoWorkDbContext, ILogger<PostService> logger)
    {
        _inspoWorkDbContext = inspoWorkDbContext;
        _logger = logger;
    }
    
    public async Task<PostResponseV1> CreatePostAsync(CreatePostRequestV1 request, CancellationToken ct = default)
    {
        var post = new Post
        {
            
        };
        
        await _inspoWorkDbContext.Posts.AddAsync(post, ct);
        await _inspoWorkDbContext.SaveChangesAsync(ct);

        return new PostResponseV1
        {

        };
    }

    public async Task<IEnumerable<PostResponseV1>> GetAllPostsAsync(CancellationToken ct = default)
    {
        await Task.Delay(100, ct);
        throw new NotImplementedException();
    }

    public async Task<PostResponseV1?> GetPostByIdAsync(string id, CancellationToken ct = default)
    {
        var objectId = new ObjectId(id);

        var post = await _inspoWorkDbContext.Posts
            .Include(post => post.PostType)
            .SingleOrDefaultAsync(p => p.PostId == objectId, ct);

        if (post is null)
            return null;

        return new PostResponseV1
        {
            PostId = post.PostId.ToString()!,
            Title = post.Title,
            Body = post.Body,
            PostType = new PostTypeResponseV1
            {
                PostTypeId = post.PostType?.PostTypeId.ToString()!,
                Name = post.PostType!.Name,
                Value = post.PostType.Value
            }
        };
    }

    public async Task<PostTypeResponseV1?> GetPostTypeByValueAsync(int value, CancellationToken ct = default)
    {
        var postType = await _inspoWorkDbContext.PostTypes
            .SingleOrDefaultAsync(pt => pt.Value == value, ct);

        if (postType is null)
            return null;

        return new PostTypeResponseV1()
        {
            PostTypeId = postType.PostTypeId.ToString()!,
        };
    }

    public async Task<IEnumerable<PostTypeResponseV1>> GetAllPostTypesAsync(CancellationToken ct = default)
    {
        await Task.Delay(100, ct);
        throw new NotImplementedException();
    }

    public async Task<PostTypeResponseV1> CreatePostTypeAsync(CreatePostTypeRequestV1 request, CancellationToken ct)
    {
        var postType = PostMap.RequestToPostType(request);

        await _inspoWorkDbContext.AddAsync(postType, ct);
        await _inspoWorkDbContext.SaveChangesAsync(ct);

        return PostMap.PostTypeToResponse(postType);
    }
}