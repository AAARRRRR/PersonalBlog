using PersonalBlog.Models;

namespace PersonalBlog.Repositories;

public interface IArticleRepository
{
    public List<string?> GetCategories();

    public List<Article> GetArticlesByCategory(List<string> categories);

    public List<Article> GetArticlesByKeywords(List<string> keywords);

    public List<Article> GetDisplayPictures(List<int> displayArticleIds);
}