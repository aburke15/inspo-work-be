using InspoWork.Common.Models.Requests;
using InspoWork.Common.Models.Responses;
using InspoWork.Data.Models;
using InspoWork.Services.Posts;
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
    public async Task<IActionResult> Get(CancellationToken ct) 
        => Ok(await _postService.GetAllPostsAsync(ct));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostByIdAsync([FromRoute] string id, CancellationToken ct)
    {
        var post = await _postService.GetPostByIdAsync(id, ct);

        if (post is null)
            return NotFound();

        return Ok(post);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePostAsync([FromBody] CreatePostRequestV1 request, CancellationToken ct)
    {
        try
        {
            var postType = await _postService.GetPostTypeByValue((int) request.PostType, ct);

            if (postType is null)
                throw new InvalidOperationException("PostType cannot be null.");

            var response = await _postService.CreatePostAsync(request, ct);

            return CreatedAtRoute(new { id = response.Id }, response);
        }
        catch (Exception e)
        {
            _logger.LogWarning(e, "Something went wrong during post creation.");
            throw;
        }
    }
}