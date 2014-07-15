﻿using UnityEngine;
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

				if(PuzzleSubmitButton.puzzleSolvEd){
					GameManager.Instance.EndChallenge(true);
					PuzzleSubmitButton.puzzleSolvEd = false;	
					Application.LoadLevel("PS_MainMapScene");
					
				}
		}
}
