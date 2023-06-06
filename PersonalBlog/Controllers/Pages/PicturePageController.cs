using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Controllers.Pages;

[AllowAnonymous]
public class PicturePageController : Controller
{
    private IPictureService _pictureService;

    public PicturePageController(IPictureService pictureService)
    {
        _pictureService = pictureService;
    }
    
    [Route("albums")]
    public async Task<IActionResult> Index()
    {
        var albums = await _pictureService.GetAllAlbums();
        var albumMap = new Dictionary<Album, Picture>();
        foreach (var album in albums)
        {
            var coverPicture = await _pictureService.GetCoverPicture(album.CoverPictureId);
            if (coverPicture != null) albumMap.Add(album, coverPicture);
        }
        var albumPageViewModel = new AlbumPageViewModel{AlbumMap = albumMap};
        
        return View(albumPageViewModel);
    }
    
    [Route("album/{albumId}")]
    public async Task<IActionResult> AlbumPictures(string albumId)
    {
        var urlStrings = HttpContext.Request.GetDisplayUrl().Split("/");
        if (int.TryParse(urlStrings[urlStrings.Length - 1], out var Id))
        {
            var picturePageModel = new PicturePageViewModel{Pictures = await _pictureService.GetAllPicturesByAlbumId(Id)};
            return View(picturePageModel);
        }
        //Todo:处理异常情况
        return View();
    }
}