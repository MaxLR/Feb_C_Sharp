using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionIntro.Models;

namespace SessionIntro.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost("/guests/new")]
    public IActionResult ProcessName(Guest guest)
    {
        // is the model state valid?
        if (!ModelState.IsValid)
        {
            // if not, render the form again
            // so user can fix mistakes
            return View("Index");
        }

        HttpContext.Session.SetString("guestName", guest.GuestName);

        // if so, allow access to dash (redirect)
        return RedirectToAction("Dashboard");
    }

    [HttpGet("/guests/home")]
    public ViewResult Dashboard()
    {
        String? guestName = HttpContext.Session.GetString("guestName");

        return View("Dashboard", guestName);
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
