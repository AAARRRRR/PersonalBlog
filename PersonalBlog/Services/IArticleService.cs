using PersonalBlog.Models;

namespace PersonalBlog.Services;

public interface IArticleService
{
    public Task<List<Article>> GetAllArticles();
    public Task<List<string?>> GetAllCategories();

    public Task<List<Article>> GetAllArticlesByCategories(List<string?> categories);

    public Task<List<Article>> GetAllArticlesByKeywords(List<string> keywords);

    public Task<List<Article>> GetDisplayArticles();

    public Task<Article?> GetArticle(int articleId);

}