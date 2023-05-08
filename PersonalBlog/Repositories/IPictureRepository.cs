using PersonalBlog.Models;

namespace PersonalBlog.Repositories;

public interface IPictureRepository
{
    public List<Picture>? GetPictures(int albumId);
    public Picture? GetCoverPicture(int albumId);
    public List<Picture>? GetDisplayPictures();
    
}