using UnityEngine;
using System.Collections;

public class PinDialog : MonoBehaviour {
    public string enteredPin = "";
    public string Id {get; set;}
    private Rect windowRect = new Rect(Screen.width/2, Screen.height/2, Screen.width/2, Screen.height/2);
    private bool displayFailure = false;
    void Start () {}
    void Update () {}
    
    void OnGUI() {
        windowRect = GUILayout.Window(0, windowRect, DisplayLoginDialog, "Please enter your PIN:");
    }

    void DisplayLoginDialog(int windowID) {
        GUILayout.Space(windowRect.height/4);

        GUILayout.BeginHorizontal();
        {
            GUILayout.FlexibleSpace();
            enteredPin = GUILayout.TextField(enteredPin, 4, GUILayout.Width(64));
            GUILayout.FlexibleSpace();
        }
        GUILayout.EndHorizontal();


        GUILayout.Space(windowRect.height/8);
       
        GUILayout.BeginHorizontal();
        {
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Login", GUILayout.ExpandWidth(false))){
                bool authenticated = GameManager.Instance.SignIn(Id, enteredPin);
                if(authenticated){
//                    GameManager.Instance.StartGame(Id);
                }
                else{
                    displayFailure = true;
                }
            }
            GUILayout.FlexibleSpace();
        }
        GUILayout.EndHorizontal();

        if(displayFailure){
            GUILayout.BeginHorizontal();
            {
                GUILayout.FlexibleSpace();
                GUILayout.Label("Incorrect PIN. Please try again.");
                GUILayout.FlexibleSpace();
            }
            GUILayout.EndHorizontal();
        }
    }
}
