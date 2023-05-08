using PersonalBlog.Models;

namespace PersonalBlog.Services;

public interface IArticleService
{
    public List<string?>? GetAllCategories();

    public List<Article>? GetAllArticlesByCategories(List<string> categories);

    public List<Article>? GetAllArticlesByKeywords(List<string> keywords);

    public List<Article>? GetDisplayArticles();
    
}