﻿using Parse;

[ParseClassName("Challenge")]
public class Challenge : ParseObject
{
    public Challenge(){}

    public Challenge(Team team, Spot spot){
        this.Team = team;
        this.Spot = spot;
    }

    [ParseFieldName("success")]
    public bool Success
    {
        get { return GetProperty<bool>("Success"); }
        set { SetProperty<bool>(value, "Success"); }
    }
    
    [ParseFieldName("spot")]
    public Spot Spot
    {
        get { return GetProperty<Spot>("Spot"); }
        set { SetProperty<Spot>(value, "Spot"); }
    }
    
    [ParseFieldName("team")]
    public Team Team
    {
        get { return GetProperty<Team>("Team"); }
        set { SetProperty<Team>(value, "Team"); }
    }
}