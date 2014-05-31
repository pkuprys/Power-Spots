using UnityEngine;
using System.Collections;

public class TeamButton : MonoBehaviour {
    public string Id {get; set;}
    public GameObject pinDialog;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnMouseOver(){
        if(Input.GetMouseButtonDown(0) && gameObject.layer != GameManager.DISABLED_LAYER){
            GameManager.Instance.UpdateSelection(this);
            GameObject go = (GameObject) Instantiate(pinDialog, new Vector3(0,0,0), Quaternion.identity);
            PinDialog dialog = (PinDialog) go.GetComponent<PinDialog>();
            dialog.Id = Id;
        }
    }
}