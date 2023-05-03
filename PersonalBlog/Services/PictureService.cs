using PersonalBlog.Models;
using PersonalBlog.Repositories;

namespace PersonalBlog.Services;

public class PictureService : IPictureService
{
    protected IPictureRepository _PictureRepository;
    protected IAlbumRepository _AlbumRepository;

    public PictureService(IPictureRepository pictureRepository, IAlbumRepository albumRepository)
    {
        _PictureRepository = pictureRepository;
        _AlbumRepository = albumRepository;
    }

    public List<Album> GetAllAlbums()
    {
        return _AlbumRepository.GetAlbums();
    }
    
    public List<Picture> GetAllPicturesByAlbumId(int albumId)
    {
        return _PictureRepository.GetPictures(albumId);
    }
    
    public List<Picture> GetDisplayPictures(List<int> displayPictureIds)
    {
        return _PictureRepository.GetDisplayPictures(displayPictureIds);
    }
    
    //TODO: 思考设置相册封面，思考是否要给picture增加isdisplay、is封面列（如果只做展示页面不做编辑页面，那么增加列的方法更易于控制
    //TODO：查资料看搜索方法

}