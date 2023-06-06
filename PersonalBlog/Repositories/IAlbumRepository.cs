using PersonalBlog.Models;

namespace PersonalBlog.Repositories;

public interface IAlbumRepository
{
    public Task<List<Album>> GetAlbums();
}