using UnityEngine;
using System.Collections;

public class PinDialogSubmit : MonoBehaviour {
    private static string BAD_PIN = "Incorrect PIN. Please try again.";
    private static string ERROR = "Error. Please try again.";

    private string message = "";
    public string enteredPin = "";

	void Start () {}
	void Update () {}

    public void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
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
                    //TODO display this
                    message = ERROR;
                }
            }
            else{
                //TODO display this
                message = BAD_PIN;
            }
            print(message);
        }
    }
}
