using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Controllers;

[AllowAnonymous]
public class HomePageController : Controller
{
    private readonly ILogger<HomePageController> _logger;
    private readonly IConfiguration _configuration;
    private readonly ICommentService _commentService;
    private readonly IPictureService _pictureService;
    private readonly IArticleService _articleService;

    public HomePageController(
        ILogger<HomePageController> logger,
        IConfiguration configuration,
        ICommentService commentService,
        IPictureService pictureService,
        IArticleService articleService
    )
    {
        _logger = logger;
        _configuration = configuration;
        _articleService = articleService;
        _pictureService = pictureService;
        _commentService = commentService;

    }
    
    public IActionResult Index()
    {
        var displayPictures = _pictureService.GetDisplayPictures();
        var displayArticles = _articleService.GetDisplayArticles();
        var displayComments = _commentService.GetDisplayComments();
        var homepageViewModel = new HomePageViewModel{
            DisplayPictures = displayPictures, DisplayArticles = displayArticles, DisplayComments = displayComments};
        return View(homepageViewModel);
    }
    
    [HttpPost]
    public IActionResult AddComment([FromForm]Comment comment)
    {
        comment.CreatedDate = DateTime.Now;
        _commentService.AddComment(comment);
        var homePageUrl = _configuration.GetSection("Kestrel")["EndPoints:Https:Url"];
        return Redirect(homePageUrl+"/homepage");
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}