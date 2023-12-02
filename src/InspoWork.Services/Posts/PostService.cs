using InspoWork.Data;
using InspoWork.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
    
    public async Task<Post> CreatePostAsync(Post post, CancellationToken ct = default)
    {
        await _inspoWorkDbContext.Posts.AddAsync(post, ct);
        await _inspoWorkDbContext.SaveChangesAsync(ct);
        
        return post;
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync(CancellationToken ct = default) 
        => await _inspoWorkDbContext.Posts.ToListAsync(ct);

    public async Task<Post?> GetPostByIdAsync(int id, CancellationToken ct = default) 
        => await _inspoWorkDbContext.Posts.SingleOrDefaultAsync(post => post.Id == id, ct);

    public async Task<PostType?> GetPostTypeByValue(int value, CancellationToken ct = default)
    {
        return await _inspoWorkDbContext.PostTypes
            .SingleOrDefaultAsync(pt => pt.PostTypeValue == value, ct);
    }
}