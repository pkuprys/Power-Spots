using Parse;

[ParseClassName("GameConfiguration")]
public class GameConfiguration : ParseObject
{
    public GameConfiguration(){}

    [ParseFieldName("key")]
    public string Key
    {
        get { return GetProperty<string>("Key"); }
        set { SetProperty<string>(value, "Key"); }
    }
    
    [ParseFieldName("value")]
    public string Value
    {
        get { return GetProperty<string>("Value"); }
        set { SetProperty<string>(value, "Value"); }
    }
}