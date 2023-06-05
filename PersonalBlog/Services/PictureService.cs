using PersonalBlog.Models;
using PersonalBlog.Repositories;

namespace PersonalBlog.Services;

public class PictureService : IPictureService
{
    private IPictureRepository _PictureRepository;
    private IAlbumRepository _AlbumRepository;

    public PictureService(IPictureRepository pictureRepository, IAlbumRepository albumRepository)
    {
        _PictureRepository = pictureRepository;
        _AlbumRepository = albumRepository;
    }

    public List<Album> GetAllAlbums()
    {
        return _AlbumRepository.GetAlbums().ToList();
    }

    public Picture? GetCoverPicture(int albumId)
    {
        return _PictureRepository.GetCoverPicture(albumId);
    }
    
    public List<Picture> GetAllPicturesByAlbumId(int albumId)
    {
        return _PictureRepository.GetPictures(albumId).OrderByDescending(x => x.UpdatedDate).ToList();
    }
    
    public List<Picture> GetDisplayPictures()
    {
        return _PictureRepository.GetDisplayPictures().OrderByDescending(x => x.UpdatedDate).ToList();
    }
    
}