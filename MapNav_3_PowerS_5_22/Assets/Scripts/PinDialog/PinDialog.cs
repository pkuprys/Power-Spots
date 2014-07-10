using UnityEngine;
using System.Collections;

public class PinDialog : MonoBehaviour {
    public string StringToEdit = "";
    public GUIStyle inputTextStyle;

    void Start(){}
    void Update(){}

    public void OnGUI(){
		StringToEdit = GUI.TextField(new Rect(Screen.width/2, Screen.height/4, 50, 30), StringToEdit, 4);
    }
}
