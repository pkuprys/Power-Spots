using UnityEngine;
using System.Collections;

public class TextInput : MonoBehaviour {
	public string StringToEdit = "Insert Code";
	public GUIStyle inputTextStyle;

	void Start () {}
    void Update () {}

	void OnGUI() {
		StringToEdit = GUI.TextField(new Rect(750, 650, 200, 35), StringToEdit, 100, inputTextStyle);
	}
}
