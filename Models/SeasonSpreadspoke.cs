using System.ComponentModel.DataAnnotations;

namespace NFLPredictionData.Models;

/*
schedule_date	schedule_season	schedule_week	schedule_playoff	team_home	score_home	score_away	team_away	team_favorite_id	spread_favorite	over_under_line	stadium	stadium_neutral	weather_temperature	weather_wind_mph	weather_humidity
*/
public class SeasonSpreadspoke
{
    public int ScheduleSeason { get; set; }

    public int Count {get; set;}

    public int CorrectCount {get; set;}

    public int IncorrectCount {get; set;}
    
    public float SpreadFavorite { get; set;}

    public float SpreadActual { get; set;}

    public float SpreadDifference {get; set;}

    //Using int so I can average the number of games with SpreadCorrect by Year
    public float SpreadCorrectPercent { get; set;}
    public SeasonSpreadspoke()
    {
        
    }
    public void AverageValues()
    {
        SpreadFavorite=(float) Math.Round(1.0*SpreadFavorite/Count,2);
        SpreadActual=(float) Math.Round(1.0*SpreadActual/Count,2);
        SpreadDifference=(float) Math.Round(1.0*SpreadDifference/Count,2);
        SpreadCorrectPercent=(float) Math.Round(1.0*SpreadCorrectPercent/Count,2);
    }
}