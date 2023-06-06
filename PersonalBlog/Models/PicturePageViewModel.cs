using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PersonalBlog.Models;

public class PicturePageViewModel : PageModel
{
    public List<Picture>? Pictures;
}