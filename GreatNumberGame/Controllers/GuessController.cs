using Microsoft.AspNetCore.Mvc;
using GreatNumberGame.Models;

namespace GreatNumberGame.Controllers;

public class GuessController: Controller
{
    [HttpGet("guesses")]
    public IActionResult Guess()
    {
        String? name = HttpContext.Session.GetString("name");

        // check if userGuess is in session
        if (HttpContext.Session.GetInt32("userGuess") is null)
        {
            HttpContext.Session.SetInt32("userGuess", 0);
        }

        if (HttpContext.Session.GetInt32("computerGuess") is null)
        {
            Random rand = new Random();
            int computerGuess = rand.Next(1, 101);
            System.Console.WriteLine(computerGuess);
            HttpContext.Session.SetInt32("computerGuess", computerGuess);
        }

        int? userGuess = HttpContext.Session.GetInt32("userGuess");

        

        ViewBag.Name = name;
        ViewBag.UserGuess = userGuess;
        ViewBag.ComputerGuess = HttpContext.Session.GetInt32("computerGuess");
        return View("Guess");
    }

    [HttpPost("guesses")]
    public IActionResult ProcessGuess(Guess guess)
    {
        if(!ModelState.IsValid)
        {
            return Guess();
        }

        HttpContext.Session.SetInt32("userGuess", guess.Num);
        return RedirectToAction("Guess", "Guess");
    }
}
