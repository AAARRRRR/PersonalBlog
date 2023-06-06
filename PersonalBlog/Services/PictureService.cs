using PersonalBlog.Models;
using PersonalBlog.Repositories;

namespace PersonalBlog.Services;

public class PictureService : IPictureService
{
    private readonly IPictureRepository _pictureRepository;
    private readonly IAlbumRepository _albumRepository;

    public PictureService(IPictureRepository pictureRepository, IAlbumRepository albumRepository)
    {
        _pictureRepository = pictureRepository;
        _albumRepository = albumRepository;
    }

    public async Task<List<Album>> GetAllAlbums()
    {
        return await _albumRepository.GetAlbums();
    }

    public async Task<Picture?> GetCoverPicture(int albumId)
    {
        return await _pictureRepository.GetCoverPicture(albumId);
    }
    
    public async Task<List<Picture>> GetAllPicturesByAlbumId(int albumId)
    {
        var pictures = await _pictureRepository.GetPictures(albumId);
        return pictures.OrderByDescending(x => x.UpdatedDate).ToList();
    }
    
    public async Task<List<Picture>> GetDisplayPictures()
    {
        var pictures = await _pictureRepository.GetDisplayPictures();
        return pictures.OrderByDescending(x => x.UpdatedDate).ToList();
    }
    
}