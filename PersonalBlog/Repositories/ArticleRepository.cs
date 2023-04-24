using PersonalBlog.Data;
using PersonalBlog.Models;
using PersonalBlog.Repositorys;

namespace PersonalBlog.Repositories;

public class ArticleRepository : RepositoryBase<Article,BlogDbContext>, IArticleRepository
{
    public ArticleRepository(BlogDbContext context) : base(context)
    {
    }

    public List<string?> GetCategories()
    {
        return All().Select(x => x.Category).Distinct().ToList();
    }

    public List<Article> GetArticlesByCategory(List<string> categories)
    {
        var results = new List<Article>();
        categories.ForEach(x => results.AddRange(All().Where(y => y.Category == x).ToList()));
        return results;
    }

    public List<Article> GetArticlesByKeywords(List<string> keywords)
    {
        var results = new List<Article>();
        keywords.ForEach(x => results.AddRange(All().Where(y => y.Content.Contains(x) | y.Title.Contains(x))));
        return results;
    }

    public List<Article> GetDisplayPictures(List<int> displayArticleIds)
    {
        var results = new List<Article>();
        displayArticleIds.ForEach(x => results.Add(Get(x)));
        return results;
    }
}