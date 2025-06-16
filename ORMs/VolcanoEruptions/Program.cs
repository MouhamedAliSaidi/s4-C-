using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
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

        // 1. First Chile
        Console.WriteLine("\n1. First eruption in Chile:");
        Console.WriteLine(eruptions.First(e => e.Location == "Chile"));

        // 2. First  Hawaiian 
        Console.WriteLine("\n2. First eruption in Hawaiian Is:");
        var hawaiian = eruptions.FirstOrDefault(e => e.Location == "Hawaiian Is");
        Console.WriteLine(hawaiian != null ? hawaiian.ToString() : "No Hawaiian Is Eruption found.");

        // 3. First Greenland
        Console.WriteLine("\n3. First eruption in Greenland:");
        var greenland = eruptions.FirstOrDefault(e => e.Location == "Greenland");
        Console.WriteLine(greenland != null ? greenland.ToString() : "No Greenland Eruption found.");

        // 4. First  New Zealand
        Console.WriteLine("\n4. First eruption after 1900 in New Zealand:");
        Console.WriteLine(eruptions.FirstOrDefault(e => e.Location == "New Zealand" && e.Year > 1900));

        // 5. Eruptions elevation > 2000m
        PrintEach(eruptions.Where(e => e.ElevationInMeters > 2000), "5. Eruptions with elevation > 2000m:");

        // 6. Eruptions name starts with "L"
        var lEruptions = eruptions.Where(e => e.Volcano.StartsWith("L")).ToList();
        PrintEach(lEruptions, "6. Volcanoes that start with 'L':");
        Console.WriteLine($"Number found: {lEruptions.Count}");

        // 7. Highest elevation
        int maxElevation = eruptions.Max(e => e.ElevationInMeters);
        Console.WriteLine($"\n7. Highest elevation: {maxElevation}");

        // 8. Volcano with highest elevation
        var highestVolcano = eruptions.First(e => e.ElevationInMeters == maxElevation);
        Console.WriteLine($"8. Volcano with highest elevation: {highestVolcano.Volcano}");

        // 9. Volcano names alphabetically
        var namesAlphabetical = eruptions.OrderBy(e => e.Volcano).Select(e => e.Volcano);
        Console.WriteLine("\n9. Volcano names alphabetically:");
        foreach (var name in namesAlphabetical)
            Console.WriteLine(name);

        // 10. Sum of all elevations
        int totalElevation = eruptions.Sum(e => e.ElevationInMeters);
        Console.WriteLine($"\n10. Total elevation sum: {totalElevation}");

        // 11. Any v erupted in 2000
        bool anyIn2000 = eruptions.Any(e => e.Year == 2000);
        Console.WriteLine($"\n11. Any volcano erupted in 2000? {anyIn2000}");

        // 12. First 3 stratovolcanoes
        PrintEach(eruptions.Where(e => e.Type == "Stratovolcano").Take(3), "12. First 3 Stratovolcanoes:");

        // 13. Eruptions before year 1000 ordered by name
        PrintEach(
            eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano),
            "13. Eruptions before 1000 CE alphabetically:"
        );

        // 14. Only volcano names for previous query
        var namesBefore1000 = eruptions
            .Where(e => e.Year < 1000)
            .OrderBy(e => e.Volcano)
            .Select(e => e.Volcano);

        Console.WriteLine("\n14. Names of volcanoes erupted before 1000 CE:");
        foreach (var name in namesBefore1000)
            Console.WriteLine(name);
    }

    // Helper 
    static void PrintEach(IEnumerable<Eruption> items, string msg = "")
    {
        Console.WriteLine("\n" + msg);
        foreach (Eruption item in items)
        {
            Console.WriteLine(item.ToString());
        }
    }
}
