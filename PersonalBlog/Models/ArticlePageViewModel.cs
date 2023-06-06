using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PersonalBlog.Models;

public class ArticlePageViewModel : PageModel
{
    public List<Article> AllArticles;

    public List<string?> AllCategories;
    
}