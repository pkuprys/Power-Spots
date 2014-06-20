using UnityEngine;
using System.Collections;

public class PinDialogSubmit : MonoBehaviour {
    private static string BAD_PIN = "Incorrect PIN. Please try again.";
    private static string ERROR = "Error. Please try again.";

    GUIText pinResponse;

	void Start () {
        GameObject go = new GameObject("PinResponse");
        go.transform.position = new Vector3(0.5f, 0.25f, 0f);
        go.transform.parent = transform.parent;
        pinResponse = (GUIText) go.AddComponent(typeof(GUIText));
        pinResponse.fontSize = 16;
    }
	void Update () {}

    public void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            string enteredPin = transform.parent.gameObject.GetComponent<PinDialog>().StringToEdit;
            Team team = LoginManager.Instance.GetSelectedTeam();
            bool authenticated = team.SignIn(enteredPin);
            if(authenticated){
                team.IsSignedIn = true;
                var save = team.SaveAsync();
                if(!save.IsFaulted){
                    LoginManager.Instance.SignIn();
                    Destroy(this.transform.parent.gameObject);
                }
                else{
                    pinResponse.text = ERROR;
                }
            }
            else{
                pinResponse.text = BAD_PIN;
            }
        }
    }
}
