using UnityEngine;
using System.Collections;

public class SpotPreview : MonoBehaviour {
    private static float HEIGHT = Screen.height/2;
    private static float WIDTH = Screen.width/2;

    private Rect windowRect = new Rect(Screen.width/3, Screen.height/3, WIDTH, HEIGHT);
    private string title;
    private string body;
    private bool canChallenge;

    public void Init(string title, string body, bool canChallenge){
        this.title = title;
        this.body = body;
        this.canChallenge = canChallenge;
    }

    void Start () {}
    void Update () {}
    
    void OnGUI() {
        windowRect = GUILayout.Window(0, windowRect, DisplayPreview, title.Replace("_", " "));
    }

    void DisplayPreview(int windowID) {
        //TODO SpotsManager.Instance.Gui(false);
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        {
            if (GUILayout.Button("X", GUILayout.ExpandWidth(false))){
                Destroy(this.gameObject);
            }
            GUILayout.Box(Resources.Load("Previews/" + title, typeof(Texture)) as Texture, GUILayout.Width(WIDTH/3), GUILayout.Height(WIDTH/3));
        }
        GUILayout.EndVertical();

        GUILayout.BeginVertical();
        {
            GUILayout.Space(20);
            GUIStyle bodyStyle = new GUIStyle();
            bodyStyle.wordWrap = true;
            bodyStyle.fontSize = 16;
            bodyStyle.normal.textColor = Color.white;
            GUILayout.Box(body, bodyStyle, GUILayout.MaxWidth(WIDTH/3), GUILayout.MaxHeight(HEIGHT));
            GUILayout.Space(10);
            if(canChallenge){
                if (GUILayout.Button("Start Challenge", GUILayout.ExpandWidth(false))){
                    StartCoroutine(GameManager.Instance.Challenge(title));
                }
            }
        }
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
    }
}
