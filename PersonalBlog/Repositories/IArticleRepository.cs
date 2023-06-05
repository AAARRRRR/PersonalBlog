using PersonalBlog.Models;

namespace PersonalBlog.Repositories;

public interface IArticleRepository
{
    public List<Article>? GetAllArticles();
    public List<string?>? GetCategories();

    public List<Article>? GetArticlesByCategories(List<string> categories);

    public List<Article>? GetArticlesByKeywords(List<string> keywords);

    public List<Article>? GetDisplayArticles();

    public Article? GetArticle(int articleId);
}