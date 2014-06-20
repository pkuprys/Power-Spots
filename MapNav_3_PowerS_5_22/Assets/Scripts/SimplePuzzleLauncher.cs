using UnityEngine;
using System.Collections;

public class SimplePuzzleLauncher : MonoBehaviour {
    private bool canClick;
    private string challengeName;

    void Start () {}
    void Update () {}

    public void SetValues(bool canClick, string challengeName){
        this.canClick = canClick;
        this.challengeName = challengeName;
        if(canClick){
            gameObject.renderer.material = (Material) Resources.Load("Buttons/StartChallenge", typeof(Material));
        }
        else{
            gameObject.renderer.material = (Material) Resources.Load("Buttons/StartChallengeDisabled", typeof(Material));
        }
    }

    public void OnMouseOver(){
        if(Input.GetMouseButtonDown(0) && canClick){
            StartCoroutine(GameManager.Instance.Challenge(challengeName));
        }
    }
}
