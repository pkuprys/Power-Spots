using UnityEngine;
using System.Collections;

public class TokenSpinner360 : MonoBehaviour {


	private Animator animator;

	// Use this for initialization
	void Start () {

		animator = this.GetComponent<Animator>();


	
	}
	
	// Update is called once per frame
	void Update () {

		//InvokeRepeating("triggerRotate", 2.0f, 2.0f);
		StartCoroutine (triggerRotate ());
	}

	IEnumerator triggerRotate(){

		animator.SetTrigger("trigger");
		print ("WOOOO!");
		yield return new WaitForSeconds (2.0f);
	}

}
