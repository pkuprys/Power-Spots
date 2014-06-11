using UnityEngine;
using System.Collections;

public class Tray : MonoBehaviour {


		public Texture trayTexture;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


		void OnGUI(){

				GUI.DrawTexture (new Rect (Screen.width / 4, Screen.height - 98, Screen.width / 2, 98), trayTexture);

		}

}
