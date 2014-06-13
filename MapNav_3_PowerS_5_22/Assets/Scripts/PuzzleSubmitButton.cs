using UnityEngine;
using System.Collections;

public class PuzzleSubmitButton : MonoBehaviour {
    public string answer = "123456789";

    void Start () {}
    void Update () {}

    public void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            if(GameObject.Find("TextInput_Field").GetComponent<TextInput>().StringToEdit.Equals(answer)){
                GameManager.Instance.EndChallenge(true);
                Application.LoadLevel("PS_MainMapScene");
            }
        }
    }
}
