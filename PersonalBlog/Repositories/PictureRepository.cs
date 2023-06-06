using LinqKit;
using PersonalBlog.Data;
using PersonalBlog.Infrastruture;
using PersonalBlog.Models;

namespace PersonalBlog.Repositories;

public class PictureRepository : RepositoryBase<Picture, BlogDbContext>, IPictureRepository
{
    public PictureRepository(BlogDbContext context) : base(context)
    {
    }

    public async Task<List<Picture>> GetPictures(int albumId)
    {
        var predicate = PredicateBuilder.False<Picture>();
        var picturePredicate = predicate.Or(x => x.AlbumId == albumId);
        return await Where(picturePredicate);
    }
    
    public async Task<Picture?> GetCoverPicture(int albumId)
    {
        return await Get(albumId);
    }
    
    public async Task<List<Picture>> GetDisplayPictures()
    {
        var predicate = PredicateBuilder.False<Picture>();
        var picturePredicate = predicate.Or(x => x.IsDisplay);
        return await Where(picturePredicate);
    }
}