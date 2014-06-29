using UnityEngine;
using System.Collections;

public class PuzzleLauncher : MonoBehaviour {
	private static string BODY_TEXT = "Lorem ipsum dolor sit amet, consectetur aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.";
    private static string POINTER = "3D_Pointer";
    private static float previewScreenX = 0f;
    private static float previewScreenY = 1f;
    private static float previewScreenZ = 0f;

    private GameObject redCircle;
    private bool isActive = false;
    private SimplePuzzleLauncher simplePuzzleLauncher = null;
    private GameObject imageQuad;
    private GUIText titleText;
    private GUIText bodyText;
	private int previewBodyMaxWidth = 440;
	private int previewBodyMaxHeight = 300;

    public GameObject spotPreview;
    public SpotsManager spotsManager;

    void Start () {
        redCircle = GameObject.Find(this.gameObject.name + "_red_circle");
        redCircle.SetActive(isActive);
        if(spotPreview.active){
            spotPreview.SetActive(false);
        }
    }
    void Update () {}

    public void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            spotPreview.SetActive(true);
            spotPreview.transform.position = new Vector3(previewScreenX, previewScreenY, previewScreenZ);
            SetTitleText();
            SetBodyText(BODY_TEXT);
            SetStartChallengeButton();
            SetPicture();
        }
    }
    private void SetTitleText(){
        if(titleText == null){
            titleText = spotPreview.transform.Find("PreviewTitle").GetComponent<GUIText>();
        }
        titleText.text = gameObject.name.Replace("_", " ");
    }

    //TODO setup body text that is specific to each spot
    private void SetBodyText(string text){
        if(bodyText == null){
            bodyText = spotPreview.transform.Find("PreviewBody").GetComponent<GUIText>();
        }
        string sizedText = Size(text);
        bodyText.text = sizedText;
    }

    //This code was lifted from comment #8 on http://forum.unity3d.com/threads/guitext-width-and-height.31351/
    private string Size(string text){
        string[] words = text.Split(' ');
        string result = "";
        Rect textArea = new Rect();
        for(int i = 0; i < words.Length; i++){
            // set the gui text to the current string including new word
            bodyText.text = result + words[i] + " ";
            // measure it
            textArea = bodyText.GetScreenRect();
            if(textArea.height > previewBodyMaxHeight){
                result += "...";
                return result;
            }
            // if it didn't fit, put word onto next line, otherwise keep it
            if(textArea.width > previewBodyMaxWidth){
                result += "\n" + words[i] + " ";
            }
            else{
                result = bodyText.text;
            }
        }
        return result;
    }

    private void SetStartChallengeButton() {
        if(simplePuzzleLauncher == null) {
            simplePuzzleLauncher = GameObject.Find("/SpotPreview/StartChallengeQuad").GetComponent<SimplePuzzleLauncher>();
        }
        simplePuzzleLauncher.SetValues(isActive, gameObject.name);
    }

    private void SetPicture() {
        if(imageQuad == null) {
            imageQuad = GameObject.Find("/SpotPreview/ImageQuad");
        }
        imageQuad.renderer.material.mainTexture = Resources.Load("Previews/" + gameObject.name, typeof(Texture)) as Texture;
    }

    public void OnTriggerEnter(Collider col){
        ToggleAnimation(col, true);
    }

    public void OnTriggerExit(Collider col){
        ToggleAnimation(col, false);
    }

    private void ToggleAnimation(Collider collider, bool turnOn){
        if(POINTER.Equals(collider.gameObject.name)){
            Spot spot = spotsManager.GetSpot(gameObject.name);
            Team owner = spot == null ? null : spot.Owner;
            bool canChallenge = owner == null || !owner.ObjectId.Equals(LoginManager.Instance.GetSelectedTeam().ObjectId);
            isActive = turnOn && canChallenge;
            redCircle.SetActive(turnOn);
        }
    }
}
