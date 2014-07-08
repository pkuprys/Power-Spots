using Parse;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class GraphicManager : MonoBehaviour {
    public GameObject mostSpotsOwnedGraphic;
    public GameObject mostSpotsTakenGraphic;
    public GameObject loseGraphic;

	void Start () {
        StartCoroutine("PickGraphic");
	}

    private IEnumerator PickGraphic(){
        bool mostSpotsTaken = false;
        bool mostSpotsOwned = false;
        string currentTeamId = LoginManager.Instance.GetSelectedTeam().ObjectId;
        Dictionary<string, int> teamsCurrentSpots = new Dictionary<string, int>();
        Dictionary<string, int> teamsMostSpots = new Dictionary<string, int>();
        var getTeams = new ParseQuery<Team>().FindAsync();
        while(!getTeams.IsCompleted) yield return null;
        IEnumerable<Team> teams = getTeams.Result;
        foreach(Team team in teams){
            teamsCurrentSpots[team.ObjectId] = 0;
            teamsMostSpots[team.ObjectId] = 0;
        }

        int maxOwned = 0;
        var getSpots = new ParseQuery<Spot>().FindAsync();
        while(!getSpots.IsCompleted) yield return null;
        IEnumerable<Spot> spots = getSpots.Result;
        foreach(Spot spot in spots){
            Team owner = spot.Owner;
            if(owner == null) continue;
            string teamId = owner.ObjectId;
            teamsCurrentSpots[teamId]++;
            if(teamsCurrentSpots[teamId] > maxOwned){
                maxOwned = teamsCurrentSpots[teamId];
            }
        }
        mostSpotsOwned = teamsCurrentSpots[currentTeamId] == maxOwned;

        int maxTaken = 0;
        var getChallenges = new ParseQuery<Challenge>().WhereEqualTo("success", true).FindAsync();
        while(!getChallenges.IsCompleted) yield return null;
        IEnumerable<Challenge> challenges = getChallenges.Result;
        foreach(Challenge challenge in challenges){
            string teamId = challenge.Team.ObjectId;
            teamsMostSpots[teamId]++;
            if(teamsMostSpots[teamId] > maxTaken){
                maxTaken = teamsMostSpots[teamId];
            }
        }
        mostSpotsTaken = teamsMostSpots[currentTeamId] == maxTaken;

        if(mostSpotsTaken){
            mostSpotsTakenGraphic.SetActive(true);
        }
        else if(mostSpotsOwned){
            mostSpotsOwnedGraphic.SetActive(true);
        }
        else{
            loseGraphic.SetActive(true);
        }
    }
}