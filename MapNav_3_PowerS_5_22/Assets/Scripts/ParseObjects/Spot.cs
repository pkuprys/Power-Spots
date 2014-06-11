using Parse;

[ParseClassName("Spot")]
public class Spot : ParseObject
{
    [ParseFieldName("name")]
    public string Name
    {
        get { return GetProperty<string>("Name"); }
        set { SetProperty<string>(value, "Name"); }
    }

    [ParseFieldName("location")]
    public ParseGeoPoint Location
    {
        get { return GetProperty<ParseGeoPoint>("Location"); }
        set { SetProperty<ParseGeoPoint>(value, "Location"); }
    }

    [ParseFieldName("owner")]
    public Team Owner
    {
        get { return GetProperty<Team>("Owner"); }
        set { SetProperty<Team>(value, "Owner"); }
    }

    [ParseFieldName("challenge")]
    public string Challenge
    {
        get { return GetProperty<string>("Challenge"); }
        set { SetProperty<string>(value, "Challenge"); }
    }
}