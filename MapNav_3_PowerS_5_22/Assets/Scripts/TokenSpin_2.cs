using UnityEngine;
using System.Collections;

public class TokenSpin_2 : MonoBehaviour {


	//stored in the object you're rotating
	public float rotation = 0; 
	public float targetRotation = 359.0f;
	public float rotateSpeed;
	bool isRotating = false;


	// Use this for initialization
	void Start () {

		InvokeRepeating ("TokenSpin", 2.0f, 2.0f);
	
	}
	
	// Update is called once per frame
	void Update () {

		//if (!isRotating) {
			//StartCoroutine ("TokenSpin");

			
		//}
	
	}



	void TokenSpin(){
		isRotating = true;

		//inside our update for the object check the rotation to see if we're where we want to be
		float rotationAmt = rotateSpeed * Time.deltaTime;
		if (rotation <= targetRotation) {
			transform.Rotate (rotationAmt, 0, 0);
			rotation += rotationAmt;
			print ("We are inside the while loop");

		} else if (rotation > 358) {
			isRotating = false;
			transform.Rotate (0, 0, 0);
			rotation = 0;
			return;
		}
	}

	//}
}
