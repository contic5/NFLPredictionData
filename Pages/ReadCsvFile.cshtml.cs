//Install-Package CsvHelper

using CsvHelper;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace NFLPredictionData.Pages;
using NFLPredictionData.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ReadCsvFileModel : PageModel
{
    public void OnGet()
    {
        /*
        string filePath = "PotentialDemoSongs.csv"; // Replace with your actual file path

        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var games = csv.GetRecords<Game>().ToList();

            foreach (var game in games)
            {
                Console.WriteLine($"Name: {game.Name}, Spotify: {game.Spotify}, Context: {game.Context}");
            }
        }
        */
    }
}