using UnityEngine;
using System.Collections;

public class GoToEndCanvasBTN : MonoBehaviour {

	public Texture goToEndCanvas;

	public float xPos;
	public float yPos;
	public float width;
	public float height;



	void OnGUI(){

		if (!goToEndCanvas) {
			Debug.LogError("Assign a Texture in the inspector.");
			return;
		}


		if (GUI.Button (new Rect (Screen.width - 200, Screen.height - 50, 40, 40), goToEndCanvas)) {

			Application.LoadLevel ("PS_EndCanvasArea_Scene");
		}

	}
}
