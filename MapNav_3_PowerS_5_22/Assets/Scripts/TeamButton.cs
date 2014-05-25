using UnityEngine;
using System.Collections;

public class TeamButton : MonoBehaviour {
    public string Id {get; set;}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnMouseOver(){
        if(Input.GetMouseButtonDown(0) && gameObject.layer != GameManager.DISABLED_LAYER){
            GameManager.Instance.UpdateSelection(this);
        }
    }
}