using UnityEngine;
using System.Collections;

public class TextInput : MonoBehaviour {

	public string stringToEdit = "Insert Code";

	public GUIStyle inputTextStyle;

	// Use this for initialization
	void Start () {

		///////inputTextStyle = new GUIStyle();
		//inputTextStyle.fontSize = 12;

	}

	void OnGUI() {
		stringToEdit = GUI.TextField(new Rect(750, 650, 200, 35), stringToEdit, 100, inputTextStyle);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
