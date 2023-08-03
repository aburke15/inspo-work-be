using Microsoft.AspNetCore.Mvc;

namespace InspoWork.API.Controllers;

public class PostController : Controller
{
    [HttpPost]
    public IActionResult CreatPostAsync()
    {
        return Ok();
    }
}