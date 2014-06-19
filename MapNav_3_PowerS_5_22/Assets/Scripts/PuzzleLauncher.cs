using UnityEngine;
using System.Collections;

public class PuzzleLauncher : MonoBehaviour {
    private GameObject redCircle;
    private bool isActive = false;
    private static string bodyText = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

    void Start () {
        redCircle = GameObject.Find(this.gameObject.name + "_red_circle");
        redCircle.SetActive(isActive);
    }
    void Update () {}

    public void OnMouseOver(){
        if(Input.GetMouseButtonDown(0) /*&& isActive*/){//TODO commented out for preview box run-through
            GameObject spotPreview = new GameObject();
            spotPreview.AddComponent<SpotPreview>().Init(this.gameObject.name, bodyText, isActive);
            //TODO commented out for preview box run-through
            //StartCoroutine(GameManager.Instance.Challenge(this.gameObject.name));
        }
    }

    public void OnTriggerEnter(Collider col){
        isActive = true;
        redCircle.SetActive(true);
    }

    public void OnTriggerExit(Collider col){
        isActive = false;
        redCircle.SetActive(false);
    }
}
