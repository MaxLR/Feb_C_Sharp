#pragma warning disable CS8618
// We can disable our warnings safely because we know the framework will assign non-null values 
// when it constructs this class for us.

using System.ComponentModel.DataAnnotations;
namespace EFLectures.Models;

public class Post
{
    [Key]  // primary key
    public int PostId { get; set; }
    
    [Required]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    [MaxLength(45, ErrorMessage = "can't be more than 45 characters.")]
    public string Topic { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    public string Body { get; set; }

    [Display(Name = "Image URL")]
    public string? ImgUrl { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}