using PersonalBlog.Models;

namespace PersonalBlog.Repositories;

public interface IArticleRepository
{
    public Task<List<Article>> GetAllArticles();
    public Task<List<string?>> GetCategories();

    public Task<List<Article>> GetArticlesByCategories(List<string?> categories);

    public Task<List<Article>> GetArticlesByKeywords(List<string> keywords);

    public Task<List<Article>> GetDisplayArticles();

    public Task<Article?> GetArticle(int articleId);
}