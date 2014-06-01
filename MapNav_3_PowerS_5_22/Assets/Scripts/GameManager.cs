using Parse;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
    public Team Team {get; set;}
    private DateTime? lastUpdatedTime;
	
    protected GameManager(){}
		
	void Start () {
		DontDestroyOnLoad(this);
    }

    void Update () {}

//    private IEnumerator InitButtons(){
//        GameObject go = new GameObject("StatusOfTeams");
//        go.transform.position = new Vector3(0.65f, 0.75f, 0);
//        statusOfTeams = (GUIText) go.AddComponent(typeof(GUIText));
//        statusOfTeams.text = GetStatusOfTeamsText();
//        statusOfTeams.fontSize = 16;
//        var query = new ParseQuery<Team>().FindAsync();
//        while(!query.IsCompleted) yield return null;
//        IEnumerable<Team> allTeams = query.Result;
//        int i = 0;
//        foreach(Team team in allTeams){
//            if(i >= TEAM_COUNT){
//                break;
//            }
//            teams.Add(team.ObjectId, team);
//            AddButton(team, i);
//            i++;
//            lastUpdatedTime = ParseUtil.GetLatestTime(team, lastUpdatedTime);
//        }
//    }
    
//    private IEnumerator CheckForUpdatesThenStartGame(){
//        yield return null;
//        while(waitForTeams){
//            yield return new WaitForSeconds(POLL_INTERVAL);
//            var query = new ParseQuery<Team>().WhereGreaterThan("updatedAt", lastUpdatedTime).FindAsync();
//            while(!query.IsCompleted) yield return null;
//            IEnumerable<Team> updatedTeams = query.Result;
//            foreach(Team team in updatedTeams){
//                GameObject button;
//                buttons.TryGetValue(team.ObjectId, out button);
//                if(team.IsSignedIn){    
//                    ++readyTeamsCount;
//                    SetStatus(team.ObjectId, DISABLED);
//                }
//                else{
//                    --readyTeamsCount;
//                    SetStatus(team.ObjectId, AVAILABLE);
//                }
//                lastUpdatedTime = ParseUtil.GetLatestTime(team, lastUpdatedTime);
//            }
//            if(readyTeamsCount == TEAM_COUNT){
//                waitForTeams = false;
//            }
//        }
//        if(isSignedIn){
//            Application.LoadLevel("PS_MainMapScene");
//        }
//        else{
//            //TODO what should happen here?
//        }
//    }
}
