using PersonalBlog.Data;
using PersonalBlog.Models;
using PersonalBlog.Repositorys;

namespace PersonalBlog.Repositories;

public class ArticleRepository : RepositoryBase<Article,BlogDbContext>
{
    public ArticleRepository(BlogDbContext context) : base(context)
    {
    }

    public IList<string?> GetCategories()
    {
        return All().Select(x => x.Category).Distinct().ToList();
    }
    
}