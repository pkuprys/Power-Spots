﻿using UnityEngine;
using System.Collections;

public class LoadMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
        GameManager.Instance.EndChallenge(false);
		Application.LoadLevel("PS_MainMapScene");
	}

}