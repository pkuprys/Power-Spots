using UnityEngine;
using System.Collections;

public class LoadMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		if (PuzzleSubmitButton.puzzleSolvEd) {
			GameManager.Instance.EndChallenge (true);
			Application.LoadLevel ("PS_MainMapScene");
			PuzzleSubmitButton.puzzleSolvEd = false;
		}
		else{
        	GameManager.Instance.EndChallenge(false);
			Application.LoadLevel("PS_MainMapScene");
			PuzzleSubmitButton.puzzleSolvEd = false;
	}

}
}