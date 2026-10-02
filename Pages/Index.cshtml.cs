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
using Microsoft.Net.Http.Headers;
using System.Collections.Immutable;

public class IndexModel : PageModel
{

    public List<SeasonSpreadspoke> SeasonSpreadspokes { get; set; }

    [BindProperty]
    public string TargetTeam {get; set;}

    public List<string> TeamNames {get; set;}

    public List<SeasonSpreadspoke> AverageBySeason(List<Spreadspoke> spreadspokes)
    {
        List<SeasonSpreadspoke> res=new List<SeasonSpreadspoke>();
        spreadspokes = spreadspokes.OrderBy(s => s.ScheduleSeason).ToList();

        int currentSeason=spreadspokes[0].ScheduleSeason;

        SeasonSpreadspoke SeasonSpreadspoke=new SeasonSpreadspoke();
        SeasonSpreadspoke.ScheduleSeason=currentSeason;

        foreach (var spreadspoke in spreadspokes)
        {
            if(spreadspoke.ScheduleSeason!=currentSeason)
            {
                SeasonSpreadspoke.AverageValues();
                res.Add(SeasonSpreadspoke);

                currentSeason=spreadspoke.ScheduleSeason;
                SeasonSpreadspoke=new SeasonSpreadspoke();
                SeasonSpreadspoke.ScheduleSeason=currentSeason;
            }
            SeasonSpreadspoke.Count+=1;
            SeasonSpreadspoke.SpreadFavorite=+spreadspoke.SpreadFavorite;
            SeasonSpreadspoke.SpreadActual+=spreadspoke.SpreadActual;
            SeasonSpreadspoke.SpreadFavorite+=spreadspoke.SpreadFavorite;
            SeasonSpreadspoke.SpreadCorrectPercent+=spreadspoke.SpreadCorrect;
            SeasonSpreadspoke.SpreadDifference+=spreadspoke.SpreadDifference;

            if(spreadspoke.SpreadCorrect==1)
            {
                SeasonSpreadspoke.CorrectCount+=1;
            }
            else
            {
                SeasonSpreadspoke.IncorrectCount+=1;
            }
        }

        SeasonSpreadspoke.AverageValues();
        res.Add(SeasonSpreadspoke);
        return res;
    }
    public void LoadData()
    {
        string filePath = "SpreadspokeData.xlsx";

        // This single line reads the sheet and binds it to your model list
        IEnumerable<Spreadspoke> spreadspokesQuery = MiniExcel.Query<Spreadspoke>(filePath,sheetName:"Data");
        if(TargetTeam!=null&&TargetTeam!=""&&TargetTeam.Length>0)
        {
            spreadspokesQuery = spreadspokesQuery.Where(spreadspoke => spreadspoke.TeamHome==TargetTeam||spreadspoke.TeamAway==TargetTeam);
        }

        List<Spreadspoke> spreadspokes=spreadspokesQuery.ToList();

        HashSet<string> uniqueTeamNames=new HashSet<string>();
        foreach(Spreadspoke spreadspoke in spreadspokes)
        {
            uniqueTeamNames.Add(spreadspoke.TeamHome);
        }

        TeamNames=uniqueTeamNames.ToList<string>();
        TeamNames.Sort();
        Console.WriteLine(TeamNames);

        SeasonSpreadspokes = AverageBySeason(spreadspokes);
        foreach (var SeasonSpreadspoke in SeasonSpreadspokes)
        {
            //Console.WriteLine($"{SeasonSpreadspoke.ScheduleSeason} | Average Spread Difference: {SeasonSpreadspoke.SpreadDifference} and Average Correct:{SeasonSpreadspoke.SpreadCorrectPercent}");
        }
    }
    public void OnGet()
    {
        LoadData();
    }
    public void OnPost()
    {
        LoadData();
    }
}