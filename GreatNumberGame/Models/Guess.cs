#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace GreatNumberGame.Models;

public class Guess
{
    [Required]
    public int Num { get; set; }
}
