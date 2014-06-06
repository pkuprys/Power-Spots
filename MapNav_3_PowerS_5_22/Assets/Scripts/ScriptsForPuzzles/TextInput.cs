using UnityEngine;
using System.Collections;

public class TextInput : MonoBehaviour {
	public string stringToEdit = "Insert Code";
    public string answer = "123456789";

	public GUIStyle inputTextStyle;

	// Use this for initialization
	void Start () {

		///////inputTextStyle = new GUIStyle();
		//inputTextStyle.fontSize = 12;

	}

	void OnGUI() {
		stringToEdit = GUI.TextField(new Rect(750, 650, 200, 35), stringToEdit, 100, inputTextStyle);
        if(answer.Equals(stringToEdit)){
            GameManager.Instance.EndChallenge(true);
            Application.LoadLevel("PS_MainMapScene");
        }
	}

	// Update is called once per frame
	void Update () {
	
	}
}
