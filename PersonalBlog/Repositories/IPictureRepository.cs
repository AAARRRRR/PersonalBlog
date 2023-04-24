using PersonalBlog.Models;

namespace PersonalBlog.Repositories;

public interface IPictureRepository
{
    public List<string> GetPictures(int albumId);

    public List<Picture> GetDisplayPictures(List<int> displayPictureIds);
}