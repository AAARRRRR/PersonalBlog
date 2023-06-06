using PersonalBlog.Data;
using PersonalBlog.Infrastruture;
using PersonalBlog.Models;
using PersonalBlog.Repositorys;

namespace PersonalBlog.Repositories;

public class AlbumRepository : RepositoryBase<Album,BlogDbContext>, IAlbumRepository
{
    public AlbumRepository(BlogDbContext context) : base(context)
    {
    }

    public async Task<List<Album>> GetAlbums()
    {
        return await All();
    }
}