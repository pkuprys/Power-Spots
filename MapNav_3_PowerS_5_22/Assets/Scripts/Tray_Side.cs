using UnityEngine;
using System.Collections;

public class Tray_Side : MonoBehaviour {
    public Texture trayGraphic; 
	public Texture trayGraphicDIM; 
	public Texture myTeamToken;

    public bool ShowTimeline {get; set;}

    void Start(){
        GameManager.Instance.RegisterTimelineCallback(this);
    }

	void OnGUI(){
		if (!ShowTimeline) {
			GUI.DrawTexture (new Rect (Screen.width - 220, 10, 200, 100), trayGraphicDIM);
		} else {
			GUI.DrawTexture (new Rect (Screen.width - 220, 10, 200, 100), trayGraphic);
		}

		GUI.DrawTexture(new Rect(Screen.width-110, 55, 20, 20), myTeamToken);
		GUI.DrawTexture(new Rect(Screen.width-150, 55, 20, 20), myTeamToken);
		GUI.DrawTexture(new Rect(Screen.width-185, 55, 20, 20), myTeamToken);
	}
}
