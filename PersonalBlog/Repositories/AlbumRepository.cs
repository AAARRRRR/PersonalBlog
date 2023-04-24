using PersonalBlog.Data;
using PersonalBlog.Models;
using PersonalBlog.Repositorys;

namespace PersonalBlog.Repositories;

public class AlbumRepository : RepositoryBase<Album,BlogDbContext>
{
    public AlbumRepository(BlogDbContext context) : base(context)
    {
    }

    public IList<string> GetAlbums()
    {
        return All().Select(x => x.Name).Distinct().ToList();
    }
}