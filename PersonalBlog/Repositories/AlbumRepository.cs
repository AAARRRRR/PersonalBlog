using PersonalBlog.Data;
using PersonalBlog.Models;
using PersonalBlog.Repositorys;

namespace PersonalBlog.Repositories;

public class AlbumRepository : RepositoryBase<Album,BlogDbContext>, IAlbumRepository
{
    public AlbumRepository(BlogDbContext context) : base(context)
    {
    }

    public List<Album>? GetAlbums()
    {
        return All().ToList();
    }
}