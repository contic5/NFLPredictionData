using MiniExcelLibs;
using System.Collections.Generic;
using System.IO;

using CsvHelper;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace NFLPredictionData.Pages;
using NFLPredictionData.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    public void OnGet()
    {
        string filePath = "SpreadspokeData.xlsx";

        // This single line reads the sheet and binds it to your model list
        IEnumerable<Spreadspoke> spreadkspokes = MiniExcel.Query<Spreadspoke>(filePath);

        foreach (var spreadkspoke in spreadkspokes)
        {
            Console.WriteLine($"{spreadkspoke.ScheduleDate} | {spreadkspoke.TeamHome} vs {spreadkspoke.TeamAway}");
        }
    }
}