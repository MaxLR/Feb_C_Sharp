using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GreatNumberGame.Models;

namespace GreatNumberGame.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("people")]
    public IActionResult ProcessName(Person person)
    {
        if (!ModelState.IsValid)
        {
            return View("Index");
        }

        HttpContext.Session.SetString("name", person.Name);
        return RedirectToAction("Guess", "Guess");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
