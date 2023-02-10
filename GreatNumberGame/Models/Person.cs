#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace GreatNumberGame.Models;

public class Person
{
    [Required]
    public String Name { get; set; }
}
