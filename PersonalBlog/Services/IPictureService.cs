using PersonalBlog.Models;

namespace PersonalBlog.Services;

public interface IPictureService
{
    public List<Album> GetAllAlbums();
    public List<Picture> GetAllPicturesByAlbumId(int albumId);
    public List<Picture> GetDisplayPictures(List<int> displayPictureIds);
}