using PersonalBlog.Models;

namespace PersonalBlog.Services;

public interface IPictureService
{
    public Task<List<Album>> GetAllAlbums();
    public Task<List<Picture>> GetAllPicturesByAlbumId(int albumId);
    public Task<List<Picture>> GetDisplayPictures();
    public Task<Picture?> GetCoverPicture(int albumId);
}