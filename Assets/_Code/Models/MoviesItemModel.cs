using System;

[Serializable]
public class MoviesItemModel 
{
    public int Id;
    public string Name;
    public int Year;
    public string Director;
    public string LeadActor;
    public string SupportActor;
    public float CriticScore;
    public float AudienceScore;
    public string Synopsis;
    public double Budget;
    public double Revenue;

    public MoviesItemModel()
    {

    }

    public MoviesItemModel(string name, int year, string director, string leadActor, string supportActor, float criticScore, float audienceScore, string synopsis, double budget, double revenue)
    {
        Name = name;
        Year = year;
        Director = director;
        LeadActor = leadActor;
        SupportActor = supportActor;
        CriticScore = criticScore;
        AudienceScore = audienceScore;
        Synopsis = synopsis;
        Budget = budget;
        Revenue = revenue;
    }

    public MoviesItemModel(int id, string name, int year, string director, string leadActor, string supportActor, float criticScore, float audienceScore, string synopsis, double budget, double revenue)
    {
        Id = id;
        Name = name;
        Year = year;
        Director = director;
        LeadActor = leadActor;
        SupportActor = supportActor;
        CriticScore = criticScore;
        AudienceScore = audienceScore;
        Synopsis = synopsis;
        Budget = budget;
        Revenue = revenue;
    }
}
