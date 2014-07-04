using UnityEngine;
using Parse;

public class ExtraParseInitialization : MonoBehaviour
{
    void Awake()
    {   // all classes that mirror objects in Parse need to be registered here
        // see https://www.parse.com/docs/unity_guide#subclasses for details
        ParseObject.RegisterSubclass<Team>();
        ParseObject.RegisterSubclass<Spot>();
        ParseObject.RegisterSubclass<Challenge>();
        ParseObject.RegisterSubclass<GameConfiguration>();

    }
}