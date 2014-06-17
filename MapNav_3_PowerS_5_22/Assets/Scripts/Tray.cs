using UnityEngine;
using System.Collections;

public class Tray : MonoBehaviour {
	public Texture trayTexture;

	public float startY;
	public float endY;
	public float duration;
	public float startTime;
	private bool toggleImg = false;

	void Awake(){

	}

	// Use this for initialization
	void Start () {

		//mapnavScript = mapNav.GetComponent(MapNav);

		duration = 0.1f;
		startY = Screen.height - 25;
		endY = Screen.height-118;
		startTime = Time.time;
		toggleImg = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		void OnGUI(){

		if (!trayTexture) {
			Debug.LogError ("Please assign a texture in the inspector.");
			return;
		}
			
		float fracTime = (Time.time - startTime) / duration;
		float yPos = Mathf.Lerp (endY, startY, fracTime);

		if (toggleImg) {
			yPos = Mathf.Lerp (endY, startY, fracTime);
		} else if (!toggleImg) {
			yPos = Mathf.Lerp (startY, endY, fracTime);
		}
		//if(mapnav.ready)
		toggleImg = GUI.Toggle (new Rect (Screen.width / 4, yPos, Screen.width / 2, 118), toggleImg, trayTexture);
	}
}
