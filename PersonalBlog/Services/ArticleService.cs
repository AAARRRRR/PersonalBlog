using PersonalBlog.Models;
using PersonalBlog.Repositories;

namespace PersonalBlog.Services;

public class ArticleService : IArticleService
{
    private IArticleRepository _ArticleRepository;

    public ArticleService(IArticleRepository articleRepository)
    {
        _ArticleRepository = articleRepository;
    }
    public List<string?>? GetAllCategories()
    {
        return _ArticleRepository.GetCategories().Order().ToList();
    }

    public List<Article>? GetAllArticlesByCategories(List<string> categories)
    {
        return _ArticleRepository.GetArticlesByCategories(categories).OrderByDescending(x => x.UpdatedDate).ToList();
    }

    public List<Article>? GetAllArticlesByKeywords(List<string> keywords)
    {
        return _ArticleRepository.GetArticlesByKeywords(keywords).OrderByDescending(x => x.UpdatedDate).ToList();
    }

    public List<Article>? GetDisplayArticles()
    {
        return _ArticleRepository.GetDisplayArticles().OrderByDescending(x => x.UpdatedDate).ToList();
    }
}