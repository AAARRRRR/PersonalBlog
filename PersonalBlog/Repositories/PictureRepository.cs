using PersonalBlog.Data;
using PersonalBlog.Models;
using PersonalBlog.Repositorys;

namespace PersonalBlog.Repositories;

public class PictureRepository : RepositoryBase<Picture, BlogDbContext>, IPictureRepository
{
    public PictureRepository(BlogDbContext context) : base(context)
    {
    }

    public List<Picture> GetPictures(int albumId)
    {
        return All().Where(x => x.AlbumId == albumId).ToList();
    }

    public List<Picture> GetDisplayPictures(List<int> displayPictureIds)
    {
        var results = new List<Picture>();
        displayPictureIds.ForEach(x => results.Add(Get(x)));
        return results;
    }
}