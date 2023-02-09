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

    [HttpGet("/viewPet")]
    public IActionResult ViewPet()
    {
        // ViewBag.Name = "Meesha";
        // ViewBag.Type = "Dog";
        // ViewBag.Age = 2;
        // ViewBag.HairColor = "Brown & White";

        Pet calebsPet = new Pet()
        {
            Name = "Meesha",
            Type = "Dog",
            Age = 2,
            HairColor = "Brown & White"
        };

        return View("ViewPet", calebsPet);
    }

    [HttpPost("/addPet")]
    public IActionResult AddPet(Pet newPet)
    {
        if(!ModelState.IsValid)
        {
            return View("Index");
        }

        if(newPet.Type == "dolphin")
        {
            ViewBag.SecretMessage = "You picked the secret pet type!";
            return View("Index");
        }
        Console.WriteLine(newPet.Name + " is a(n)" + newPet.Age + " years old pet with " + newPet.HairColor + " hair");
        // return RedirectToAction("Index");
        // return Redirect("/");
        return View("ViewPet", newPet);
    }

    [HttpGet("{**path}")]
    public RedirectToActionResult Unknown()
    {
        Console.WriteLine("Page not found");
        return RedirectToAction("Index");
    }

    [HttpGet("/privacy")]
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
