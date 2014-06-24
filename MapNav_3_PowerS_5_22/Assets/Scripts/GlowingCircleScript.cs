using UnityEngine;
using System.Collections;

public class GlowingCircleScript : MonoBehaviour {

	public Texture yellowCircletexture;
		public Texture blueCircletexture;
	
		public TextMesh pressMeText;

		public int numAnswersRequired;
	
		void Start(){
				pressMeText.renderer.enabled = false; 

		}

	// Update is called once per frame
	void Update () {
	
				if (PuzzleSubmitButton_2.correctAnswers >= numAnswersRequired) {
						renderer.material.mainTexture = blueCircletexture;
						pressMeText.renderer.enabled = true; 
				}

	}

		void OnMouseDown(){

				GameManager.Instance.EndChallenge(true);
				Application.LoadLevel("PS_MainMapScene");

		}
}
