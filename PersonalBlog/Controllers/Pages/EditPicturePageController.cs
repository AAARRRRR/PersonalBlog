using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PersonalBlog.Services;

namespace PersonalBlog.Controllers.Pages;

public class EditPicturePageController : Controller
{
    public IPictureService _pictureService;
    
    public EditPicturePageController(IPictureService pictureService)
    {
        _pictureService = pictureService;
    }
    
    [Authorize(Policy = "Email")]
    [Route("picture/upload")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult OnPostUploadAsync()
    {
        return Ok();
    }
}