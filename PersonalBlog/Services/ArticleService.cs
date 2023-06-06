using PersonalBlog.Models;
using PersonalBlog.Repositories;

namespace PersonalBlog.Services;

public class ArticleService : IArticleService
{
    private readonly IArticleRepository _articleRepository;

    public ArticleService(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public async Task<List<Article>> GetAllArticles()
    {
        var allArticles = await _articleRepository.GetAllArticles();
        return allArticles.OrderByDescending(x => x.UpdatedDate).ToList();
    }
    public async Task<List<string?>> GetAllCategories()
    {
        var allCategories = await _articleRepository.GetCategories();
        return allCategories;
    }

    public async Task<List<Article>> GetAllArticlesByCategories(List<string?> categories)
    {
        var articles = await _articleRepository.GetArticlesByCategories(categories);
        return articles.OrderByDescending(x => x.UpdatedDate).ToList();
    }

    public async Task<List<Article>> GetAllArticlesByKeywords(List<string> keywords)
    {
        var articles = await _articleRepository.GetArticlesByKeywords(keywords);
        return articles.OrderByDescending(x => x.UpdatedDate).ToList();
    }

    public async Task<List<Article>> GetDisplayArticles()
    {
        var articles = await _articleRepository.GetDisplayArticles();
        return articles.OrderByDescending(x => x.UpdatedDate).ToList();
    }

    public async Task<Article?> GetArticle(int articleId)
    {
        return await _articleRepository.GetArticle(articleId);
    }
}