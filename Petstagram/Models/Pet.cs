using System.ComponentModel.DataAnnotations;


public class Pet
{
    [Required(ErrorMessage = "is required.")]
    public string Name { get; set; }
    public string Type { get; set; }
    [MinLength(3)]
    public string HairColor { get; set; }
    [Range(0, Int32.MaxValue, ErrorMessage = "must be at least 0 years old")]
    public int Age { get; set; }
}