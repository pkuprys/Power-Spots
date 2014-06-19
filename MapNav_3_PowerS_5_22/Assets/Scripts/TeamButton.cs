using UnityEngine;
using System.Collections;

public class TeamButton : MonoBehaviour {
    public string Id {get; set;}
    public GameObject pinDialog;

	void Start () {}
	void Update () {}

    public void OnMouseOver(){
        if(Input.GetMouseButtonDown(0) && canInteract()){
            LoginManager.Instance.UpdateSelection(this);
            LoginManager.Instance.Gui(false);
            Instantiate(pinDialog, new Vector3(0f,2f,-10f), Quaternion.identity);
        }
    }

    private bool canInteract(){
        return gameObject.layer != GameConstants.DISABLED_LAYER && LoginManager.Instance.IsGuiOn();
    }
}