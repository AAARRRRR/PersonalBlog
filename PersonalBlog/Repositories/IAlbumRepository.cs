using PersonalBlog.Models;

namespace PersonalBlog.Repositories;

public interface IAlbumRepository
{
    public List<Album> GetAlbums();
}