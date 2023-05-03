using PersonalBlog.Models;
using PersonalBlog.Repositories;

namespace PersonalBlog.Services;

public class ArticleService : IArticleService
{
    protected IArticleRepository _ArticleRepository;

    public ArticleService(IArticleRepository articleRepository)
    {
        _ArticleRepository = articleRepository;
    }
    public List<string?> GetAllCategories()
    {
        return _ArticleRepository.GetCategories();
    }

    public List<Article> GetAllArticlesByCategories(List<string> categories)
    {
        return _ArticleRepository.GetArticlesByCategories(categories);
    }

    public List<Article> GetAllArticlesByKeywords(List<string> keywords)
    {
        return _ArticleRepository.GetArticlesByKeywords(keywords);
    }

    public List<Article> GetDisplayArticles(List<int> displayArticleIds)
    {
        return _ArticleRepository.GetDisplayArticles(displayArticleIds);
    }
}