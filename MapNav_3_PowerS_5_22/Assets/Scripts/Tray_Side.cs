using UnityEngine;
using System.Collections;

public class Tray_Side : MonoBehaviour {


		public Texture trayGraphic; 
		public Texture trayGraphicDIM; 

		public Texture myTeamToken;

		void OnGUI(){

				GUI.DrawTexture(new Rect(Screen.width-220, 10, 200, 100), trayGraphicDIM);
				GUI.DrawTexture(new Rect(Screen.width-110, 55, 20, 20), myTeamToken);
				GUI.DrawTexture(new Rect(Screen.width-150, 55, 20, 20), myTeamToken);
				GUI.DrawTexture(new Rect(Screen.width-185, 55, 20, 20), myTeamToken);
		}
}
