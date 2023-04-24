using PersonalBlog.Data;
using PersonalBlog.Models;
using PersonalBlog.Repositorys;

namespace PersonalBlog.Repositories;

public class PictureRepository : RepositoryBase<Picture, BlogDbContext>
{
    public PictureRepository(BlogDbContext context) : base(context)
    {
    }

    public IList<string> GetPictures(int albumId)
    {
        return All().Where(x => x.AlbumId == albumId).Select(x => x.PictureRoute).ToList();
    }

}