using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GameLinq.Models;

namespace GameLinq.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        List<VideoGame> games = MakeGameList();
        List<VideoGame> gamesStartingWithO = games.Where(game => game.Title.StartsWith('O')).ToList();
        List<VideoGame> playStationGames = games.Where(game => game.Platform.Equals("PlayStation")).ToList();
        List<VideoGame> matureGames = games.Where(game => game.Rating.Equals("M")).ToList();
        VideoGame? godOfWar = games.FirstOrDefault(game => game.Title.Equals("God of War"));

        List<int> numbers = new List<int>()
        {
            5, 15, 20, 0, 1, 3, 25
        };

        List<int> numsAboveTen = numbers.Where(num => num > 10).ToList();
        System.Console.WriteLine(String.Join(", ", numsAboveTen));

        /*
        long way:
        foreach(int number in numbers)
        {
            if (number > 10)
            {
                numsAboveTen.Add(number);
            }
        }
        */

        List<string> names = new List<string>()
        {
            "Neil", "Mark", "Lauren", "Jake", "Adam", "Garrett"
        };

        int shortestNameLength = names.Min(name => name.Length);
        System.Console.WriteLine($"Shortest Name is {shortestNameLength} characters long.");

        ViewBag.selectedGame = godOfWar;
        return View(games);
    }

    public List<VideoGame> MakeGameList()
    {
        List<VideoGame> games = new List<VideoGame> {
            new VideoGame("Apex Legends", "Riot", "E", 0, "Xbox"),
            new VideoGame("The Last of Us", "Naughty Dog", "M", 39.99, "PlayStation"),
            new VideoGame("Untitled Goose Game", "House House", "E", 29.99, "PC"),
            new VideoGame("Super Mario Bros.", "Nintendo", "E", 49.99, "SNES"),
            new VideoGame("Marvel's Spider-Man", "Insomniac Games", "T", 32.05, "PlayStation"),
            new VideoGame("Elden Ring", "FromSoftware", "M", 59.99, "PC"),
            new VideoGame("Forza Horizon 5", "Xbox Game Studios", "T", 44.99, "Xbox"),
            new VideoGame("Metroid: Dread", "Nintendo", "T", 49.95, "Nintendo Switch"),
            new VideoGame("Grounded", "Obsidian Entertainment", "T", 18.99, "Xbox"),
            new VideoGame("Animal Crossing: New Horizons", "Nintendo", "T", 49.99, "Nintendo Switch"),
            new VideoGame("World of Warcraft", "Blizzard", "E", 49.99, "PC"),
            new VideoGame("God of War", "Santa Monica Studio", "M", 19.99, "PlayStation"),
            new VideoGame("Overwatch 2", "Blizzard", "T", 0, "PC"),
            new VideoGame("Psychonauts 2", "Double Fine", "T", 69.99, "Xbox"),
            new VideoGame("Ghost of Tsushima", "Sucker Punch Productions", "M", 25.99, "PlayStation"),
            new VideoGame("Super Smash Bros. Ultimate", "Bandai Namco", "E", 59.99, "Nintendo Switch"),
            new VideoGame("Sea of Thieves", "Rare", "T", 8.99, "Xbox"),
            new VideoGame("Super Mario Odyssey", "Nintendo", "E", 38.99, "Nintendo Switch"),
            new VideoGame("Hollow Knight", "Team Cherry", "E", 34.99, "PC"),
            new VideoGame("Uncharted 4: A Thief's End", "Naughty Dog", "T", 12.99, "PlayStation"),
            new VideoGame("Disco Elysium", "ZA/UM", "M", 15.98, "PC"),
            new VideoGame("Horizon: Zero Dawn", "Guerrilla Games", "T", 9.99, "PlayStation"),
            new VideoGame("Halo Infinite", "343 Industries", "T", 29.97, "Xbox"),
            new VideoGame("The Legend of Zelda: Breath of the Wild", "Nintendo", "E", 39.99, "Nintendo Switch"),
            new VideoGame("Cuphead", "Studio MDHR", "E", 39.99, "PC"),
        };
        return games;
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
