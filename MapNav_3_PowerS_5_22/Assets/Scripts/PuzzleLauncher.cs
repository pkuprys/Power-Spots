using UnityEngine;
using System.Collections;

public class PuzzleLauncher : MonoBehaviour {
	void Start () {}
	void Update () {
        if(isActive){
            //play animation?
        }
    }

    private bool isActive = false;

    public void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
             StartCoroutine(GameManager.Instance.Challenge(this.gameObject.name));
        }
    }

    public void OnTriggerEnter (Collider col){
        isActive = true;
    }

    public void OnTriggerExit (Collider col){
        isActive = false;
    }
}
