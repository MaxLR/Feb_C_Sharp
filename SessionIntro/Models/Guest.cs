#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace SessionIntro.Models;

public class Guest
{
    [Required(ErrorMessage = "Please enter your name.")]
    public String GuestName { get; set; }
}
