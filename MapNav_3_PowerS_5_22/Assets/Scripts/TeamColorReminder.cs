using UnityEngine;
using System.Collections;

public class TeamColorReminder : MonoBehaviour {


	public Texture teamColorReminder;


	void OnGUI(){

		if (!teamColorReminder) {
			Debug.LogError("Assign a Texture in the inspector.");
			return;
		}


		GUI.DrawTexture(new Rect(Screen.width-50, Screen.height -50, 40, 40), teamColorReminder);

	}
}
