using UnityEngine;
using System.Collections;

public class PinDialog : MonoBehaviour {
    public string enteredPin = "";
    public string Id {get; set;}
    private Rect windowRect = new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2);
    private string teamName;
    private string message = "";

    private static string BAD_PIN = "Incorrect PIN. Please try again.";
    private static string ERROR = "Error. Please try again.";

    void Start () {}
    void Update () {}
    
    void OnGUI() {
        if(teamName == null){
            teamName = GameManager.Instance.GetTeam(Id).Name;
        }
        windowRect = GUILayout.Window(0, windowRect, DisplayLoginDialog, "Please enter the four digit PIN for " + teamName);
    }

    void DisplayLoginDialog(int windowID) {
        GameManager.Instance.Gui(false);
        GUILayout.Space(windowRect.height/2);

        GUILayout.BeginHorizontal();
        {
            GUILayout.FlexibleSpace();
            enteredPin = GUILayout.TextField(enteredPin, 4, GUILayout.Width(64));
            GUILayout.FlexibleSpace();
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(20);
       
        GUILayout.BeginHorizontal();
        {
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Cancel", GUILayout.ExpandWidth(false))){
                GameManager.Instance.Gui(true);
                Destroy(this.gameObject);
            }
            if (GUILayout.Button("Sign In", GUILayout.ExpandWidth(false))){
                Team team = GameManager.Instance.GetTeam(Id);
                bool authenticated = team.SignIn(enteredPin);
                if(authenticated){
                    team.IsSignedIn = true;
                    var save = team.SaveAsync();
                    if(!save.IsFaulted){
                        Destroy(this.gameObject);
                    }
                    else{
                        message = ERROR;
                    }
                }
                else{
                    message = BAD_PIN;
                }
            }
            GUILayout.FlexibleSpace();
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        {
            GUILayout.FlexibleSpace();
            GUILayout.Label(message);
            GUILayout.FlexibleSpace();
        }
        GUILayout.EndHorizontal();
    }
}
