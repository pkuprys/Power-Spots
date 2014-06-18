using UnityEngine;
using System.Collections;

public class GlowingCircleScript : MonoBehaviour {

	public Texture yellowCircletexture;
	
	// Update is called once per frame
	void Update () {
	
		if (PuzzleSubmitButton_2.correctAnswers >= 3)
			renderer.material.mainTexture = yellowCircletexture;

	}
}
