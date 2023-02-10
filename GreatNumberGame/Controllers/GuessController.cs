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
            HttpContext.Session.SetInt32("numGuesses", 0);
        }

        // check if computerGuess is in session
        if (HttpContext.Session.GetInt32("computerGuess") is null)
        {
            Random rand = new Random();
            int computerGuess = rand.Next(1, 101);
            System.Console.WriteLine(computerGuess);
            HttpContext.Session.SetInt32("computerGuess", computerGuess);
        }

        // set local variables
        int? userGuess = HttpContext.Session.GetInt32("userGuess");
        int? compGuess = HttpContext.Session.GetInt32("computerGuess");
        int? numGuesses = HttpContext.Session.GetInt32("numGuesses");

        // set game state variables
        ViewBag.IsTooLow = false;
        ViewBag.IsTooHigh = false;
        ViewBag.IsCorrect = false;

        if (userGuess < compGuess && numGuesses > 0)
        {
            ViewBag.IsTooLow = true;
        }
        else if (userGuess > compGuess && numGuesses > 0)
        {
            ViewBag.IsTooHigh = true;
        }
        else if (userGuess == compGuess && numGuesses > 0)
        {
            ViewBag.IsCorrect = true;
        }

        ViewBag.Name = name;
        ViewBag.UserGuess = userGuess;
        ViewBag.ComputerGuess = HttpContext.Session.GetInt32("computerGuess");
        ViewBag.NumGuesses = HttpContext.Session.GetInt32("numGuesses");
        return View("Guess");
    }

    [HttpPost("guesses")]
    public IActionResult ProcessGuess(Guess guess)
    {
        if(!ModelState.IsValid)
        {
            return Guess();
        }

        int? numGuesses = HttpContext.Session.GetInt32("numGuesses");
        
        if (numGuesses is not null)
        {
            numGuesses++;
            HttpContext.Session.SetInt32("numGuesses", (int)numGuesses);
        }

        HttpContext.Session.SetInt32("userGuess", guess.Num);
        return RedirectToAction("Guess", "Guess");
    }

    [HttpGet("guesses/reset")]
    public IActionResult ResetGuess()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}
