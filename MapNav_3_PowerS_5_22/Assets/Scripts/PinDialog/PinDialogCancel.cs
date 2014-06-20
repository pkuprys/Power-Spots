using UnityEngine;
using System.Collections;

public class PinDialogCancel : MonoBehaviour {
	void Start () {}
	void Update () {}

    public void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            LoginManager.Instance.UpdateSelection(null);
            LoginManager.Instance.Gui(true);
            Destroy(this.transform.parent.gameObject);
        }
    }
}
