using System.ComponentModel.DataAnnotations;

namespace NFLPredictionData.Models;

/*
schedule_date	schedule_season	schedule_week	schedule_playoff	team_home	score_home	score_away	team_away	team_favorite_id	spread_favorite	over_under_line	stadium	stadium_neutral	weather_temperature	weather_wind_mph	weather_humidity
*/
public class AveragedSpreadspoke
{
    public int ScheduleSeason { get; set; }
    public float SpreadFavorite { get; set;}

    public float SpreadActual { get; set;}

    public float SpreadDifference {get; set;}

    //Using int so I can average the number of games with SpreadCorrect by Year
    public float SpreadCorrect { get; set;}
    public AveragedSpreadspoke()
    {
        
    }
}