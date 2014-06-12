using UnityEngine;
using System.Collections;

public class PuzzleLauncher : MonoBehaviour {
    private GameObject redCircle;
    private bool isActive = false;

    void Start () {
        redCircle = GameObject.Find(this.gameObject.name + "_red_circle");
        redCircle.active = isActive;
    }
    void Update () {}


    public void OnMouseOver(){
        if(Input.GetMouseButtonDown(0) && isActive){
            print("STARTING");
             StartCoroutine(GameManager.Instance.Challenge(this.gameObject.name));
        }
    }

    public void OnTriggerEnter (Collider col){
        isActive = true;
        redCircle.SetActive(true);
    }

    public void OnTriggerExit (Collider col){
        isActive = false;
        redCircle.SetActive(false);
    }
}
