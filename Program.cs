using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

public class Concert
{
    public int Id { get; set; }
    public bool ReducedVenue { get; set; }
    public DateTime Date { get; set; }
    public string Performer { get; set; }
    public int BeginsAt { get; set; }
    public int FullCapacitySales { get; set; }
}

class Program
{
    static void Main()
    {
        string currentDirectory = Environment.CurrentDirectory;
        string filePath = Path.Combine(currentDirectory, "concert_data.json");

        // Read the JSON file
        string concertData = File.ReadAllText(filePath);

        // Deserialize the JSON data into a List<Concert>.
        List<Concert> concerts = JsonSerializer.Deserialize<List<Concert>>(concertData);

        // 1. Return a new List<Concert> ordered by the Date value, going from the present date.
        List<Concert> sortedConcertsByDate = concerts
            .Where(c => c.Date >= DateTime.Now)
            .OrderBy(c => c.Date)
            .ToList();

        // 2. Return a new List<Concert> with all concerts of a ReducedVenue (true).
        List<Concert> reducedVenueConcerts = concerts
            .Where(c => c.ReducedVenue)
            .ToList();

        // 3. Return a new List<Concert> with all concerts during 2024.
        List<Concert> concertsIn2024 = concerts
            .Where(c => c.Date.Year == 2024)
            .ToList();

        // 4. Return a new List<Concert> with the five biggest projected sales figures.
        List<Concert> top5ConcertsBySales = concerts
            .OrderByDescending(c => c.FullCapacitySales)
            .Take(5)
            .ToList();

        // 5. Return a new List<Concert> with all concerts taking place on a Friday.
        List<Concert> fridayConcerts = concerts
            .Where(c => c.Date.DayOfWeek == DayOfWeek.Friday)
            .ToList();

    
    }
}
