using Parse;

[ParseClassName("Team")]
public class Team : ParseObject
{
    public Team(){}

    [ParseFieldName("PIN")]
    public string PIN
    {
        get { return GetProperty<string>("PIN"); }
        set { SetProperty<string>(value, "PIN"); }
    }

    [ParseFieldName("name")]
    public string Name
    {
        get { return GetProperty<string>("Name"); }
        set { SetProperty<string>(value, "Name"); }
    }

    [ParseFieldName("color")]
    public string Color
    {
        get { return GetProperty<string>("Color"); }
        set { SetProperty<string>(value, "Color"); }
    }

    [ParseFieldName("isSignedIn")]
    public bool IsSignedIn
    {
        get { return GetProperty<bool>("IsSignedIn"); }
        set { SetProperty<bool>(value, "IsSignedIn"); }
    }

    [ParseFieldName("dayOneTokenCount")]
    public int DayOneTokenCount
    {
        get { return GetProperty<int>("DayOneTokenCount"); }
        set { SetProperty<int>(value, "DayOneTokenCount"); }
    }

    [ParseFieldName("dayTwoTokenCount")]
    public int DayTwoTokenCount
    {
        get { return GetProperty<int>("DayTwoTokenCount"); }
        set { SetProperty<int>(value, "DayTwoTokenCount"); }
    }

    public bool IsDayOneCardVisible(){
        return DayOneTokenCount != null && DayOneTokenCount >= 3;
    }

    public bool IsDayTwoCardVisible(){
        return DayTwoTokenCount != null && DayTwoTokenCount >= 3;
    }

    public bool IsTimelineButtonActive(){
        return GetTokenCount() != null && GetTokenCount() >= 3;
    }

    public bool SignIn(string enteredPin){
        if(IsSignedIn){
            return false;
        }
        return this.PIN.Equals(enteredPin);
    }

    public int GetTokenCount(){
        string day = LoginManager.Instance.GetDay();
        if(GameConstants.DAY_ONE.Equals(day)){
            return DayOneTokenCount;
        }
        else if (GameConstants.DAY_TWO.Equals(day)){
            return DayTwoTokenCount;
        }
        return 0;
    }
}
