/*using UnityEngine;
using System.Collections;

public class TokenSpinner : MonoBehaviour {





	public float speed = 90.0f; // degrees per second
	private Vector3 curEuler3;
	private bool rotating = false;


	void Start(){
		Vector3 curEuler = transform.eulerAngles;
	}


	void Update(){

		StartCoroutine (SpinToken (360));

	}


	IEnumerator SpinToken(float angle){
		if (rotating) return;
		rotating = true; 

		float newAngle = curAngle.y+angle;
		while (curEuler.y < newAngle){
			// move a little step at constant speed to the new angle:
			curEuler.y = Mathf.MoveTowards(curEuler.y, newAngle, speed*Time.deltaTime);
			transform.eulerAngles = curEuler; // update the object's rotation...
			yield return new WaitForSeconds(2.0f); // and let Unity free till the next frame
		}
		rotating = false;
	}

}








	// Update is called once per frame
	//void Update () {
	
		//StartCoroutine (TokenSpin());
	//InvokeRepeating("SpinToken", 3, 2.0F);
	//}

	/*void SpinToken(){
		float tCycle = 0;
		float t = Time.time;

		if (t>tCycle){
			tCycle = t+3;
			if (transform.localEulerAngles.x>359)
				transform.localEulerAngles.x = tCycle;
			//else
			//transform.localEulerAngles.x = 180;
		}
	}*/
	/*public float rotateSpeed;
	//stored in the object you're rotating
	public float rotation = 0; 
	public float targetRotation = 360;

	void Update(){
		//InvokeRepeating("SpinToken", 3, 2.0F);
		StartCoroutine (SpinToken ());
	}
	IEnumerator SpinToken(){
		//inside our update for the object check the rotation to see if we're where we want to be
		float rotationAmt = rotateSpeed * Time.deltaTime;
		while (rotation <= targetRotation) {
			transform.Rotate (rotationAmt, 0, 0);
			rotation += rotationAmt;
			print ("We are inside the while loop");
		} 

		//transform.Rotate (0, 0, 0);
		//rotation = 0;
		if (rotation >= targetRotation) {
			transform.Rotate (0, 0, 0);
			rotation = 0;
			yield return new WaitForSeconds(2.0f);
		}

	}*/
//}
	