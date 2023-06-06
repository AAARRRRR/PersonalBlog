using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PersonalBlog.Models;

public class AlbumPageViewModel : PageModel
{
    public Dictionary<Album,Picture> AlbumMap;
}