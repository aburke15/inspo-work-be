using InspoWork.Data;
using InspoWork.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InspoWork.Api.Services;

public class PostService : IPostService
{
    private readonly IrohDbContext _irohDbContext;
    private readonly ILogger<PostService> _logger;
    
    public PostService(IrohDbContext irohDbContext, ILogger<PostService> logger)
    {
        _irohDbContext = irohDbContext;
        _logger = logger;
    }
    
    public async Task<Post> CreatePostAsync(Post post, CancellationToken ct = default)
    {
        await _irohDbContext.Posts.AddAsync(post, ct);
        await _irohDbContext.SaveChangesAsync(ct);
        
        return post;
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync(CancellationToken ct = default) 
        => await _irohDbContext.Posts.ToListAsync(ct);

    public async Task<Post?> GetPostByIdAsync(int id, CancellationToken ct = default) 
        => await _irohDbContext.Posts.SingleOrDefaultAsync(post => post.Id == id, ct);

    public async Task<PostType?> GetPostTypeByValue(int value, CancellationToken ct = default)
    {
        return await _irohDbContext.PostTypes
            .SingleOrDefaultAsync(pt => pt.PostTypeValue == value, ct);
    }
}