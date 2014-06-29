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

    [ParseFieldName("tokenCount")]
    public int TokenCount
    {
        get { return GetProperty<int>("TokenCount"); }
        set { SetProperty<int>(value, "TokenCount"); }
    }

    public bool IsTextSnippetVisible(){
        return TokenCount != null && TokenCount >= 3;
    }

    public bool SignIn(string enteredPin){
        if(IsSignedIn){
            return false;
        }
        return this.PIN.Equals(enteredPin);
    }
}
