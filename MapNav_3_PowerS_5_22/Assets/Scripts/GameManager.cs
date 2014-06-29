using Parse;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
    private Challenge pendingChallenge;
    private SpotsManager spotsManager;
    private string spotNameThatShouldHaveToken;
    private Tray_Side traySideCallback;

    protected GameManager(){}
		
	void Start () {}
    void Update () {}

    public IEnumerator Challenge(string spotName){
        spotNameThatShouldHaveToken = null;
        Spot spot = GetSpotsManager().GetSpot(spotName);
        Team team = LoginManager.Instance.GetSelectedTeam();
        pendingChallenge = new Challenge(team, spot);
        var save = pendingChallenge.SaveAsync();
        while(!save.IsCompleted) yield return null;
        if(save.IsFaulted || save.IsCanceled){
            pendingChallenge = null;
            print("PROBLEMS");
            //TODO display an error OR "disable" the spot
        }
        else{
            Application.LoadLevel(spot.Challenge);;
        }
    }

    public IEnumerator EndChallenge(bool success){
        if(pendingChallenge == null){
            return false;
        }
        else{
            if(success){
                spotNameThatShouldHaveToken = pendingChallenge.Spot.Name;
            }
            pendingChallenge.Success = success;
            pendingChallenge.SaveAsync();
            Team team = LoginManager.Instance.GetSelectedTeam();
            var fetch = team.FetchAsync();
            while(!fetch.IsCompleted) yield return null;
            //TODO put this logic elsewhere
            traySideCallback.ShowTimeline = team.IsTextSnippetVisible();
        }
    }

    private SpotsManager GetSpotsManager(){
        if(spotsManager == null){
            GameObject spotsManagerObject = GameObject.Find("SpotsManager");
            spotsManager = spotsManagerObject.GetComponent<SpotsManager>();
        }
        return spotsManager;
    }

    public bool HasToken(string spotName){
        return spotName != null && spotName.Equals(spotNameThatShouldHaveToken);
    }

    public void RegisterTimelineCallback(Tray_Side traySide){
        traySideCallback = traySide;
    }
}
