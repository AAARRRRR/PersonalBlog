namespace PersonalBlog.Models;

public class Comment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Contact { get; set; }
    public string Content { get; set; }
    public bool IsDisplay { get; set; }
    public DateTime CreatedDate { get; set; }
}