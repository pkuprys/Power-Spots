using UnityEngine;
using System.Collections;

public class GlowingCircleScript : MonoBehaviour {

	public Texture yellowCircletexture;
		public TextMesh pressMeText;
	
		void Start(){
				pressMeText.renderer.enabled = false; 

		}

	// Update is called once per frame
	void Update () {
	
				if (PuzzleSubmitButton_2.correctAnswers >= 3) {
						renderer.material.mainTexture = yellowCircletexture;
						pressMeText.renderer.enabled = true; 
				}

	}

		void OnMouseDown(){

				GameManager.Instance.EndChallenge(true);
				Application.LoadLevel("PS_MainMapScene");

		}
}
