using UnityEngine;
using System.Collections;

public class TimerDothAppear : MonoBehaviour {

	public float timeToFinish;

		public GUIStyle timerGUI;

		float minutes = 60;
		float seconds = 0;
		float miliseconds = 0;

	void OnGUI(){

				//We need a switch here that only displays this gui timer info if a game designer has flipped a boolean in the database to make the timer appear


				if(miliseconds <= 0){
						if(seconds <= 0){
								minutes--;
								seconds = 59;
						}
						else if(seconds >= 0){
								seconds--;
						}

						miliseconds = 100;
				}

				miliseconds -= Time.deltaTime * 60;

				string timerTime = string.Format("{0}:{1}:{2}", minutes, seconds, (int)miliseconds);

				GUI.Label(new Rect(Screen.width-250, 10, 300, 20), "Signal Loss Countdown: \n             " + timerTime, timerGUI);
	
	}
}
