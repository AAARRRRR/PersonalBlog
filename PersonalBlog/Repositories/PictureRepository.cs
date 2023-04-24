using PersonalBlog.Data;
using PersonalBlog.Models;
using PersonalBlog.Repositorys;

namespace PersonalBlog.Repositories;

public class PictureRepository : RepositoryBase<Picture, BlogDbContext>, IPictureRepository
{
    public PictureRepository(BlogDbContext context) : base(context)
    {
    }

    public List<string> GetPictures(int albumId)
    {
        return All().Where(x => x.AlbumId == albumId).Select(x => x.PictureRoute).ToList();
    }

    public List<Picture> GetDisplayPictures(List<int> displayPictureIds)
    {
        var results = new List<Picture>();
        displayPictureIds.ForEach(x => results.Add(Get(x)));
        return results;
    }
}