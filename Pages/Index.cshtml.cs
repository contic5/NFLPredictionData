using MiniExcelLibs;
using System.Collections; // Required namespace
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
using Microsoft.Extensions.ObjectPool;

public class IndexModel : PageModel
{

    public List<AveragedSpreadspoke> AveragedSpreadSpokes { get; set; }

    public List<AveragedSpreadspoke> AverageBySeason(List<Spreadspoke> spreadspokes)
    {
        List<AveragedSpreadspoke> res=new List<AveragedSpreadspoke>();
        spreadspokes = spreadspokes.OrderBy(s => s.ScheduleSeason).ToList();

        int currentSeason=spreadspokes[0].ScheduleSeason;
        int count=0;
        int spreadFavoriteSum=0;
        int spreadActualSum=0;
        int spreadDifference=0;
        int spreadCorrect=0;

        AveragedSpreadspoke averagedSpreadspoke=new AveragedSpreadspoke();
        foreach (var spreadspoke in spreadspokes)
        {
            if(spreadspoke.ScheduleSeason!=currentSeason)
            {
                averagedSpreadspoke=new AveragedSpreadspoke();

                averagedSpreadspoke.ScheduleSeason=currentSeason;
                averagedSpreadspoke.SpreadFavorite=(float) Math.Round(1.0*spreadFavoriteSum/count,2);
                averagedSpreadspoke.SpreadActual=(float) Math.Round(1.0*spreadActualSum/count,2);
                averagedSpreadspoke.SpreadDifference=(float) Math.Round(1.0*spreadDifference/count,2);
                averagedSpreadspoke.SpreadCorrect=(float) Math.Round(1.0*spreadCorrect/count,2);
                res.Add(averagedSpreadspoke);

                currentSeason=spreadspoke.ScheduleSeason;

                count=0;
                spreadFavoriteSum=0;
                spreadActualSum=0;
                spreadDifference=0;
                spreadCorrect=0;
            }
            count+=1;
            spreadFavoriteSum+=spreadspoke.SpreadFavorite;
            spreadActualSum+=spreadspoke.SpreadActual;
            spreadDifference+=spreadspoke.SpreadDifference;
            spreadCorrect+=spreadspoke.SpreadCorrect;
        }

        averagedSpreadspoke=new AveragedSpreadspoke();
        averagedSpreadspoke.ScheduleSeason=currentSeason;
        averagedSpreadspoke.SpreadFavorite=(float) Math.Round(1.0*spreadFavoriteSum/count,2);
        averagedSpreadspoke.SpreadActual=(float) Math.Round(1.0*spreadActualSum/count,2);
        averagedSpreadspoke.SpreadDifference=(float) Math.Round(1.0*spreadDifference/count,2);
        averagedSpreadspoke.SpreadCorrect=(float) Math.Round(1.0*spreadCorrect/count,2);
        res.Add(averagedSpreadspoke);
        return res;
    }
    public void OnGet()
    {
        string filePath = "SpreadspokeData.xlsx";

        // This single line reads the sheet and binds it to your model list
        IEnumerable<Spreadspoke> spreadspokesQuery = MiniExcel.Query<Spreadspoke>(filePath,sheetName:"Data");
        List<Spreadspoke> spreadspokes=spreadspokesQuery.ToList();

        AveragedSpreadSpokes=AverageBySeason(spreadspokes);
        foreach (var averagedSpreadspoke in AveragedSpreadSpokes)
        {
            Console.WriteLine($"{averagedSpreadspoke.ScheduleSeason} | Average Spread Difference: {averagedSpreadspoke.SpreadDifference} and Average Correct:{averagedSpreadspoke.SpreadCorrect}");
        }
    }
}