using LINQEruption.models;

List<Eruption> eruptions = new List<Eruption>()
    {
        new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
        new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
        new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
        new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
        new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
        new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
        new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
        new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
        new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
        new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
        new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
        new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
        new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
    };

// Example Query - Prints all Stratovolcano eruptions
List<Eruption> stratovolcanoEruptions = eruptions.Where(eruption => eruption.Type == "Stratovolcano").ToList();
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");

// Execute Assignment Tasks here!
// 1. Use LINQ to find the first eruption that is in Chile and print the result.
Eruption? firstInChile = eruptions.FirstOrDefault(eruption => eruption.Location.Equals("Chile"));
System.Console.WriteLine($"First eruption in Chile: {firstInChile}");

// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(List<Eruption> eruptions, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption eruption in eruptions)
    {
        Console.WriteLine(eruption.ToString());
    }
}

