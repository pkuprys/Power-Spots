using UnityEngine;
using System.Collections;

public class PuzzleLauncher : MonoBehaviour {
	void Start () {}
	void Update () {}

    public string Puzzle;

    public void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            bool startChallenge = GameManager.Instance.Challenge(this.gameObject.name);
            if(startChallenge){
                Application.LoadLevel(Puzzle);
            }
            else{
                //TODO display a warning message
            }
        }
    }
}
