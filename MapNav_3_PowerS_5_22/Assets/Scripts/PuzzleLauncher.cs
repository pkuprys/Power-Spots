using UnityEngine;
using System.Collections;

public class PuzzleLauncher : MonoBehaviour {
    private static string POINTER = "3D_Pointer";
    private static string PREVIEW_PARENT = "/Main Camera";

    private GameObject redCircle;
    private bool isActive = false;
    private SimplePuzzleLauncher simplePuzzleLauncher = null;
    private GameObject imageQuad;
    private GUIText titleText;
    private GUIText bodyText;
	private int previewBodyMaxWidth = 280;
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
            SetTitleText();
            SetBodyText();
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

    private void SetBodyText(){
        if(bodyText == null){
            bodyText = spotPreview.transform.Find("PreviewBody").GetComponent<GUIText>();
        }
        TextAsset txt = (TextAsset) Resources.Load("Previews/" + gameObject.name + "_text", typeof(TextAsset));
        string sizedText = Size(txt.text);
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
            simplePuzzleLauncher = GameObject.Find(PREVIEW_PARENT + "/SpotPreview/StartChallengeQuad").GetComponent<SimplePuzzleLauncher>();
        }
        simplePuzzleLauncher.SetValues(isActive && CanChallenge(), gameObject.name);
    }

    private void SetPicture() {
        if(imageQuad == null) {
            imageQuad = GameObject.Find(PREVIEW_PARENT + "/SpotPreview/ImageQuad");
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
            isActive = turnOn && CanChallenge();
            redCircle.SetActive(turnOn);
        }
    }

    private bool CanChallenge(){
        Spot spot = spotsManager.GetSpot(gameObject.name);
        if(spot == null) return false;
        return spot.Owner == null || !(spot.Owner.ObjectId.Equals(LoginManager.Instance.GetSelectedTeam().ObjectId));
    }
}
