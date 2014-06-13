using UnityEngine;
using System.Collections;

public class TextInput : MonoBehaviour {
	public string StringToEdit = "Insert Code";
	public GUIStyle inputTextStyle;
    public float xPos;
    public float yPos;
    public float width;
    public float height;

	void Start () {}
    void Update () {}

	void OnGUI() {
				StringToEdit = GUI.TextField(new Rect(xPos, yPos, width, height), StringToEdit, 70, inputTextStyle);
	}
}
