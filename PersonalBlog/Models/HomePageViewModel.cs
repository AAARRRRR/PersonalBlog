using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PersonalBlog.Models;

public class HomePageViewModel : PageModel
{
    public List<Picture>? DisplayPictures;
    public List<Article>? DisplayArticles;
    public List<Comment>? DisplayComments;
}