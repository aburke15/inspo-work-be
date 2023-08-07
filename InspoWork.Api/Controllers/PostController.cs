using InspoWork.Api.Requests;
using InspoWork.Api.Services;
using InspoWork.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace InspoWork.Api.Controllers;

[ApiController]
[Route("api/v1/posts")]
public class PostController : Controller
{
    private readonly ILogger<PostController> _logger;
    private readonly IPostService _postService;
    
    public PostController(ILogger<PostController> logger, IPostService postService)
    {
        _logger = logger;
        _postService = postService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPostsAsync(CancellationToken ct) 
        => Ok(await _postService.GetAllPostsAsync(ct));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPostByIdAsync([FromRoute] int id, CancellationToken ct)
    {
        var post = await _postService.GetPostByIdAsync(id, ct);

        if (post is null)
            return NotFound();

        return Ok(post);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePostAsync([FromBody] CreatePostRequestV1 request, CancellationToken ct)
    {
        var postType = await _postService.GetPostTypeByValue((int) request.PostType, ct);

        if (postType is null)
            throw new InvalidOperationException("PostType cannot be null.");
        
        var post = new Post()
        {
            Title = request.Title,
            Body = request.Body,
            PostTypeId = postType.Id
        };

        post = await _postService.CreatePostAsync(post, ct);

        return CreatedAtRoute(new { id = post.Id }, post);
    }
}