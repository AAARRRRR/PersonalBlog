using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models;

public class Comment
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string? Contact { get; set; }
    [Required]
    
    public string Content { get; set; }
    public bool IsDisplay { get; set; }
    public DateTime CreatedDate { get; set; }
}