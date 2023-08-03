using InspoWork.Api.Requests;
using InspoWork.Data;
using Microsoft.AspNetCore.Mvc;

namespace InspoWork.Api.Controllers;

public class PostController : Controller
{
    private readonly IrohDbContext _irohDbContext;
    
    public PostController(IrohDbContext irohDbContext)
    {
        _irohDbContext = irohDbContext;
    }
    
    [HttpPost]
    public IActionResult CreatePostAsync([FromBody] CreatePostRequestV1 request)
    {
        return Ok();
    }
}