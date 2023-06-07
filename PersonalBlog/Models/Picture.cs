namespace PersonalBlog.Models;

public class Picture
{
    public int Id { get; set; }
    public string PictureRoute { get; set; }
    public byte[] Content { get; set; }
    public int AlbumId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsDisplay { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public virtual Album Album { get; set; }
    
}