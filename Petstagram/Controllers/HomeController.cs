using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Petstagram.Models;

namespace Petstagram.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost("/addPet")]
    public IActionResult AddPet(string PetName, int Age, string HairColor, string PetType)
    {
        if(PetType == "dolphin")
        {
            ViewBag.SecretMessage = "You picked the secret pet type!";
            return View("Index");
        }
        Console.WriteLine(PetName + " is a(n)" + Age + " years old pet with " + HairColor + " hair");
        // return RedirectToAction("Index");
        return Redirect("/");
    }

    [HttpGet("{**path}")]
    public RedirectToActionResult Unknown()
    {
        Console.WriteLine("Page not found");
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
