using UnityEngine;
using System.Collections;

public class Tray_Side : MonoBehaviour {
    public Texture timelineButtonTexture; 
    public Texture timelineButtonTextureDisabled; 
    public Texture trayGraphicDIM; 
	public Texture myTeamToken;

    public bool ShowTimeline {get; set;}

	void OnGUI(){
        GUI.DrawTexture(new Rect(Screen.width-220, 10, 200, 100), trayGraphicDIM);
        GUI.DrawTexture(new Rect(Screen.width-110, 55, 20, 20), myTeamToken);
        GUI.DrawTexture(new Rect(Screen.width-150, 55, 20, 20), myTeamToken);
        GUI.DrawTexture(new Rect(Screen.width-185, 55, 20, 20), myTeamToken);
        GUIStyle style = new GUIStyle();
        style.padding = new RectOffset(0,0,0,0);
        if(GUI.Button(new Rect(Screen.width-68, 22, 32, 64), ShowTimeline ? timelineButtonTexture : timelineButtonTextureDisabled, style) && ShowTimeline){
            //TODO
        }
	}
}
