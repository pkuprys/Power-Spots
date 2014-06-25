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

		void OnMouseDown(){

				GameManager.Instance.EndChallenge(true);
				Application.LoadLevel("PS_MainMapScene");

		}
}
