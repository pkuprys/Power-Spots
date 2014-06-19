using UnityEngine;
using System.Collections;

public class PinDialog : MonoBehaviour {
    public string StringToEdit = "0000";
    public GUIStyle inputTextStyle;

    void Start(){}
    void Update(){}

    public void OnGUI(){
        StringToEdit = GUI.TextField(new Rect(transform.position.x, transform.position.y, 102, 30), StringToEdit, 4);
    }
}
