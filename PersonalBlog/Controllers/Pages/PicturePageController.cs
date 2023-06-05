using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Controllers;

[AllowAnonymous]
public class PicturePageController : Controller
{
    private IPictureService _pictureService;

    public PicturePageController(IPictureService pictureService)
    {
        _pictureService = pictureService;
    }
    
    [Route("albums")]
    public IActionResult Index()
    {
        var albums = _pictureService.GetAllAlbums();
        var albumMap = new Dictionary<Album, Picture>();
        foreach (var album in albums)
        {
            var coverPicture = _pictureService.GetCoverPicture(album.CoverPictureId);
            albumMap.Add(album,coverPicture);
        }
        var albumPageViewModel = new AlbumPageViewModel{AlbumMap = albumMap};
        
        return View(albumPageViewModel);
    }
    
    [Route("album/{albumId}")]
    public IActionResult AlbumPictures(string albumId)
    {
        var urlStrings = HttpContext.Request.GetDisplayUrl().Split("/");
        int Id;
        if (int.TryParse(urlStrings[urlStrings.Length - 1], out Id))
        {
            var picturePageModel = new PicturePageViewModel{Pictures = _pictureService.GetAllPicturesByAlbumId(Id)};
            return View(picturePageModel);
        }
        //Todo:处理异常情况
        return View();
    }
}