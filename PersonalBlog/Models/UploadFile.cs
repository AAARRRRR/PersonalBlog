using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models;

public class UploadFile
{
    [Required]
    [Display(Name = "File")]
    public IFormFile FormFile { get; set; }
}