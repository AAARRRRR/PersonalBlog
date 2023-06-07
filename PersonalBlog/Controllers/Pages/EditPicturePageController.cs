using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Data;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Controllers.Pages;

public class EditPicturePageController : Controller
{
    private readonly IPictureService _pictureService;
    private readonly BlogDbContext _blogDbContext;
    private readonly IConfiguration _configuration;
    
    public EditPicturePageController(IPictureService pictureService, BlogDbContext blogDbContext, IConfiguration configuration)
    {
        _pictureService = pictureService;
        _blogDbContext = blogDbContext;
        _configuration = configuration;
    }
    
    [Authorize(Policy = "Email")]
    [Route("picture/upload")]
    public async Task<IActionResult> Index()
    {
        var albums = await _pictureService.GetAllAlbums();
        var bufferedSingleFileUploadDbModel = new BufferedSingleFileUploadDbModel
        {
            Albums = albums
        };
        return View(bufferedSingleFileUploadDbModel);
    }
    
    [HttpPost]
    [Authorize(Policy = "Email")]
    public async Task<IActionResult> OnPostUploadAsync([FromForm] BufferedSingleFileUploadDbModel bufferedSingleFileUploadDbModel)
    {

        using (var memoryStream = new MemoryStream())
        {
            await bufferedSingleFileUploadDbModel.FileUpload.FormFile.CopyToAsync(memoryStream);

            // Upload the file if less than 2 MB
            if (memoryStream.Length < 2097152)
            {
                var picture = new Picture()
                {
                    Name = bufferedSingleFileUploadDbModel.FileUpload.Name,
                    AlbumId = bufferedSingleFileUploadDbModel.FileUpload.AlbumId,
                    Content = memoryStream.ToArray(),
                    CreatedDate = DateTime.Now,
                    IsDisplay = false
                };

                _blogDbContext.Pictures.Add(picture);

                await _blogDbContext.SaveChangesAsync();
            }
            else
            {
                ModelState.AddModelError("Picture", "The picture is too large.");
            }
        }

        var siteUrl = _configuration.GetSection("Kestrel")["EndPoints:Https:Url"];
        return Redirect(siteUrl+"/homepage");
    }
}