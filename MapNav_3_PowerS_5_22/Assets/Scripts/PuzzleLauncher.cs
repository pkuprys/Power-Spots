using UnityEngine;
using System.Collections;

public class PuzzleLauncher : MonoBehaviour {
	void Start () {}
	void Update () {}

    public void OnMouseOver(){
        GameManager.Instance.Challenge(this.gameObject.name);
        if(Input.GetMouseButtonDown(0)){
            Application.LoadLevel("PS_Puzzle1");
        }
    }
}
