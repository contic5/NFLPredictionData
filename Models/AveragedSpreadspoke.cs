using System.ComponentModel.DataAnnotations;

namespace NFLPredictionData.Models;

/*
schedule_date	schedule_season	schedule_week	schedule_playoff	team_home	score_home	score_away	team_away	team_favorite_id	spread_favorite	over_under_line	stadium	stadium_neutral	weather_temperature	weather_wind_mph	weather_humidity
*/
public class AveragedSpreadspoke
{
    public int ScheduleSeason { get; set; }
    public int SpreadFavorite { get; set;}

    public int SpreadActual { get; set;}

    public int SpreadDifference {get; set;}

    //Using int so I can average the number of games with SpreadCorrect by Year
    public int SpreadCorrect { get; set;}
    public AveragedSpreadspoke()
    {
        
    }
}