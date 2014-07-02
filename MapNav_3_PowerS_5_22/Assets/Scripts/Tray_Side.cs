using UnityEngine;
using System.Collections;

public class Tray_Side : MonoBehaviour {
    public Texture timelineButtonTexture; 
    public Texture timelineButtonTextureDisabled; 
    public Texture trayGraphicDIM; 
	public Texture myTeamToken;

    public bool ShowTimeline {get; set;}
    public int TokenCount {get; set;}

    void Start(){
        Team team = LoginManager.Instance.GetSelectedTeam();
        myTeamToken = Resources.Load("hexSpots/" + team.Color + GameConstants.COLOR_SUFFIX, typeof(Texture)) as Texture;
    }

	void OnGUI(){
        GUI.DrawTexture(new Rect(Screen.width-220, 10, 200, 100), trayGraphicDIM);
        if(TokenCount > 0){
            GUI.DrawTexture(new Rect(Screen.width-185, 55, 20, 20), myTeamToken);
        }
        if(TokenCount > 1){
            GUI.DrawTexture(new Rect(Screen.width-150, 55, 20, 20), myTeamToken);
        }
        if(TokenCount > 2){
            GUI.DrawTexture(new Rect(Screen.width-110, 55, 20, 20), myTeamToken);
        }

        GUIStyle style = new GUIStyle();
        style.padding = new RectOffset(0,0,0,0);
        if(GUI.Button(new Rect(Screen.width-68, 22, 32, 64), ShowTimeline ? timelineButtonTexture : timelineButtonTextureDisabled, style) && ShowTimeline){
            //TODO what should happen here?
        }
	}
}
