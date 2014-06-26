using UnityEngine;
using System.Collections;

public class TeamColorReminder : MonoBehaviour {
    private static string REMINDER_PREFIX = "MyTeamIs";
	public Texture teamColorReminder;

    public void Start(){
        Team team = LoginManager.Instance.GetSelectedTeam();
        teamColorReminder = Resources.Load("MyTeamColorGraphic/" + REMINDER_PREFIX + team.Name, typeof(Texture)) as Texture;
    }

	public void OnGUI(){
		if (!teamColorReminder) {
			Debug.LogError("Assign a Texture in the inspector.");
			return;
		}
				GUI.DrawTexture(new Rect(Screen.width-250, Screen.height-100, 200, 100), teamColorReminder);
	}
}
