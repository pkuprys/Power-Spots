using UnityEngine;
using System.Collections;

public class SimplePuzzleLauncher : MonoBehaviour {
    private bool canClick = true;

    void Start () {}
    void Update () {}

    public void OnMouseOver(){
        if(Input.GetMouseButtonDown(0) && canClick){
            StartCoroutine(GameManager.Instance.Challenge(this.gameObject.name));
        }
    }
}
