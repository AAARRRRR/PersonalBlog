using PersonalBlog.Data;
using PersonalBlog.Models;
using PersonalBlog.Repositorys;

namespace PersonalBlog.Repositories;

public class PictureRepository : RepositoryBase<Picture, BlogDbContext>, IPictureRepository
{
    public PictureRepository(BlogDbContext context) : base(context)
    {
    }

    public List<Picture>? GetPictures(int albumId)
    {
        return All().Where(x => x.AlbumId == albumId).ToList();
    }
    
    public Picture? GetCoverPicture(int albumId)
    {
        return Get(albumId);
    }
    
    public List<Picture>? GetDisplayPictures()
    {
        return All().Where(x => x.IsDisplay).ToList();
    }
}