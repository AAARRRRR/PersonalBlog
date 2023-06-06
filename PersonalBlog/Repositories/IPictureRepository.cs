using PersonalBlog.Models;

namespace PersonalBlog.Repositories;

public interface IPictureRepository
{
    public Task<List<Picture>> GetPictures(int albumId);
    public Task<Picture?> GetCoverPicture(int albumId);
    public Task<List<Picture>> GetDisplayPictures();
    
}