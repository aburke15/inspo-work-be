using InspoWork.Api.Requests;
using InspoWork.Data;
using InspoWork.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InspoWork.Api.Controllers;

[ApiController]
[Route("api/v1/posts")]
public class PostController : Controller
{
    private readonly ILogger<PostController> _logger;
    private readonly IrohDbContext _irohDbContext;
    
    public PostController(ILogger<PostController> logger, IrohDbContext irohDbContext)
    {
        _logger = logger;
        _irohDbContext = irohDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPostsAsync(CancellationToken ct) 
        => Ok(await _irohDbContext.Posts.ToListAsync(ct));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPostByIdAsync([FromRoute] int id, CancellationToken ct)
    {
        var post = await _irohDbContext.Posts.SingleOrDefaultAsync(p => p.Id == id, ct);

        if (post is null)
            return NotFound();

        return Ok(post);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePostAsync([FromBody] CreatePostRequestV1 request, CancellationToken ct)
    {
        var post = new Post()
        {
            Title = request.Title,
            Body = request.Body,
            PostType = request.PostType
        };

        await _irohDbContext.AddAsync(post, ct);
        await _irohDbContext.SaveChangesAsync(ct);

        return CreatedAtRoute(new { id = post.Id }, post);
    }
}