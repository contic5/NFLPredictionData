using System.ComponentModel.DataAnnotations;

namespace NFLPredictionData.Models;

/*
schedule_date	schedule_season	schedule_week	schedule_playoff	team_home	score_home	score_away	team_away	team_favorite_id	spread_favorite	over_under_line	stadium	stadium_neutral	weather_temperature	weather_wind_mph	weather_humidity
*/
public class Spreadspoke
{
    public DateTime ScheduleDate { get; set; }
    public int ScheduleSeason { get; set; }
    public int ScheduleWeek { get; set; }
    public bool SchedulePlayoff { get; set; }
    public string TeamHome { get; set; }

    public int ScoreHome { get; set; }
    public string TeamAway { get; set; }
    public int ScoreAway { get; set; }

    public string TeamFavorite { get; set;}

    public int SpreadFavorite { get; set;}

    public int SpreadActual { get; set;}

    //Using int so I can average the number of games with SpreadCorrect by Year
    public int SpreadCorrect { get; set;}
    public Spreadspoke()
    {
        
    }
}