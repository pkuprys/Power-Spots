using Parse;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
    private static string SPOT = "_spot";
    public Team Team {get; set;}
    private DateTime? lastUpdatedTime;

    private Dictionary<string, GameObject> mapSpots = new Dictionary<string, GameObject>(GameConstants.SPOT_COUNT);
    private Dictionary<string, Spot> spots = new Dictionary<string, Spot>(GameConstants.SPOT_COUNT);

    private Challenge pendingChallenge;
	
    protected GameManager(){}
		
	void Start () {
		DontDestroyOnLoad(this);
        StartCoroutine("InitSpots");
    }

    void Update () {}

    private IEnumerator InitSpots(){
        var query = new ParseQuery<Spot>().FindAsync();
        while(!query.IsCompleted) yield return null;
        IEnumerable<Spot> allSpots = query.Result;
        foreach(Spot spot in allSpots){
            GameObject mapSpot = GameObject.Find(spot.Name);
            spots.Add(spot.Name, spot);
            mapSpots.Add(spot.Name, mapSpot);
            lastUpdatedTime = ParseUtil.GetLatestTime(spot, lastUpdatedTime);

            Team owner = spot.Owner;
            if(owner == null){
                continue;
            }
            Task<Team> fetchTask = owner.FetchAsync();
            while(!fetchTask.IsCompleted) yield return null;
            string coloredSpotName = "Spots/" + owner.Color + SPOT;
            Texture texture = Resources.Load(coloredSpotName, typeof(Texture)) as Texture;
            mapSpot.renderer.material.mainTexture = texture;
        }
    }

    public void Challenge(string spotName){
        Spot spot;
        spots.TryGetValue(spotName, out spot);
        pendingChallenge = new Challenge(Team, spot);
        pendingChallenge.SaveAsync();
    }

    public void EndChallenge(bool success){
        if(pendingChallenge == null){
            return;
        }
        pendingChallenge.Success = success;
        pendingChallenge.SaveAsync();
    }
    
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
