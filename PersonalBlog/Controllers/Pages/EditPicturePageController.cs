using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PersonalBlog.Services;

namespace PersonalBlog.Controllers.Pages;

public class EditPicturePageController : Controller
{
    private readonly IPictureService _pictureService;
    
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
    
}