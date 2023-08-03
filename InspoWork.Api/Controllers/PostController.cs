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
    private readonly IrohDbContext _irohDbContext;
    
    public PostController(IrohDbContext irohDbContext)
    {
        _irohDbContext = irohDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPostsAsync()
    {
        if (_irohDbContext.Posts != null) return Ok(await _irohDbContext.Posts.ToListAsync());
        return NotFound();
    }

    [HttpGet("id:int")]
    public async Task<IActionResult> GetPostByIdAsync([FromRoute] int id)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePostAsync([FromBody] CreatePostRequestV1 request)
    {
        var post = new Post()
        {
            Title = request.Title,
            Body = request.Body
        };

        await _irohDbContext.AddAsync(post);
        await _irohDbContext.SaveChangesAsync();

        return CreatedAtRoute(new { id = post.Id }, post);
    }
}