using Parse;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class LoginManager : Singleton<LoginManager> {
    //BUTTON CONFIGURATIONS
	private static float X_ANCHOR = -5.0f;
	private static float Y_ANCHOR = 3.0f;
    private static float Z_ANCHOR = -2.0f;
	private static float X_ROW_DIFF = 2.5f;
	private static float Y_COL_DIFF = -2.5f;
    private static float X_OFFSET = X_ROW_DIFF/2;
    private static int BUTTONS_PER_ROW = 4;
    //BUTTON NAME PIECES
    private static string TEAM = "Team";
    private static string DISABLED = "Disabled";
    private static string SELECTED = "Selected";
    private static string AVAILABLE = "";
    //TEAM STATUS TEXT
    private static string STATUS_START = "Waiting for ";
    private static string STATUS_END = " teams to sign in...";

    public GUIText statusOfTeams;
    public GameObject buttonPrefab;

    private Dictionary<string, GameObject> buttons = new Dictionary<string, GameObject>(GameConstants.TEAM_COUNT);
    private Dictionary<string, Team> teams = new Dictionary<string, Team>(GameConstants.TEAM_COUNT);
    private TeamButton currentSelection;
    private DateTime? lastUpdatedTime;
    private int readyTeamsCount = 0;
    private bool waitForTeams = true;
    private bool isGuiOn = true;
    private bool isSignedIn = false;
	
    protected LoginManager(){}
		
	void Start () {
        StartCoroutine("InitButtons");
        StartCoroutine("CheckForUpdatesThenStartGame");

        #pragma warning disable 219
        //calling this to make sure it is instantiated
        GameManager gm = GameManager.Instance;
        #pragma warning restore 219
    }

    void Update () {}

    private IEnumerator InitButtons(){
        GameObject go = new GameObject("StatusOfTeams");
		go.transform.position = new Vector3(0.29f, 0.18f, 0);
        statusOfTeams = (GUIText) go.AddComponent(typeof(GUIText));
        statusOfTeams.text = GetStatusOfTeamsText();
        statusOfTeams.fontSize = 16;
        var query = new ParseQuery<Team>().FindAsync();
        while(!query.IsCompleted) yield return null;
        IEnumerable<Team> allTeams = query.Result;
        int i = 0;
        foreach(Team team in allTeams){
            if(i >= GameConstants.TEAM_COUNT){
                break;
            }
            teams.Add(team.ObjectId, team);
            AddButton(team, i);
            i++;
            lastUpdatedTime = ParseUtil.GetLatestTime(team, lastUpdatedTime);
        }
    }
    
    private IEnumerator CheckForUpdatesThenStartGame(){
        yield return null;
        while(waitForTeams){
            yield return new WaitForSeconds(GameConstants.POLL_INTERVAL);
            var query = new ParseQuery<Team>().WhereGreaterThan("updatedAt", lastUpdatedTime).FindAsync();
            while(!query.IsCompleted) yield return null;
            IEnumerable<Team> updatedTeams = query.Result;
            foreach(Team team in updatedTeams){
                GameObject button;
                buttons.TryGetValue(team.ObjectId, out button);
                if(team.IsSignedIn){    
                    ++readyTeamsCount;
                    SetStatus(team.ObjectId, DISABLED);
                }
                else{
                    --readyTeamsCount;
                    SetStatus(team.ObjectId, AVAILABLE);
                }
                lastUpdatedTime = ParseUtil.GetLatestTime(team, lastUpdatedTime);
            }
            if(readyTeamsCount == GameConstants.TEAM_COUNT){
                waitForTeams = false;
            }
        }
        if(isSignedIn){
            Application.LoadLevel("PS_MainMapScene");
        }
        else{
            //TODO what should happen here?
        }
    }

    private void AddButton(Team team, int index){
        int row = index / BUTTONS_PER_ROW;
        float x = (index % BUTTONS_PER_ROW) * X_ROW_DIFF + ((row % 2) * X_OFFSET);
        float y = row * Y_COL_DIFF;
        Vector3 position = new Vector3(x + X_ANCHOR, y + Y_ANCHOR, Z_ANCHOR);
        GameObject go = (GameObject) Instantiate(buttonPrefab, position, Quaternion.identity);
        go.renderer.material.mainTexture = GetButtonTexture(team, AVAILABLE);
        go.renderer.material.shader = Shader.Find("Unlit/Transparent");
		TeamButton button = (TeamButton) go.GetComponent<TeamButton>();
        string id = team.ObjectId;
        button.Id = id;
		buttons.Add(id, go);
		if(team.IsSignedIn){
            ++readyTeamsCount;
            SetStatus(id, DISABLED);
		}
	}
    
    private Texture GetButtonTexture(Team team, string modifier) {
        string teamButtonName = "Buttons/" + TEAM + team.Name + modifier;
        return Resources.Load(teamButtonName, typeof(Texture)) as Texture;
    }

	public void UpdateSelection(TeamButton newSelection){
		if(currentSelection != null){
            SetStatus(currentSelection.Id, AVAILABLE);
		}
		currentSelection = newSelection;
        if(currentSelection != null){
            SetStatus(currentSelection.Id, SELECTED);
        }
	}
    
    private void SetStatus(string id, string status){
        GameObject go;
        buttons.TryGetValue(id, out go);
        Team team = GetTeam(id);
        go.renderer.material.mainTexture = GetButtonTexture(team, status);
        if(DISABLED.Equals(status)){
            go.layer = GameConstants.DISABLED_LAYER;
        }
        else {
            go.layer = GameConstants.ENABLED_LAYER;
        }
        statusOfTeams.text = GetStatusOfTeamsText();
    }

    private string GetStatusOfTeamsText(){
        return STATUS_START + (GameConstants.TEAM_COUNT - readyTeamsCount) + STATUS_END;
    }

    public Team GetTeam(string id){
        Team team;
        teams.TryGetValue(id, out team);
        return team;
    }

    public void Gui(bool state){
        isGuiOn = state;
    }

    public bool IsGuiOn(){
        return isGuiOn;
    }

    public void SignIn(){
        Gui(false);
        isSignedIn = true;
    }

    public Team GetSelectedTeam(){
        return GetTeam(currentSelection.Id);
    }
}
