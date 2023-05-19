namespace PersonalBlog.Models;

public class Article
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    public string? Summary { get; set; }
    public string Content { get; set; }
    public string? Category { get; set; }
    public bool IsDisplay { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}