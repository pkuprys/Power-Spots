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
    private bool updateTokens = true;
    private TimerDothAppear timerDothAppear;

    public int TokenCount {get; set;}
    
    protected GameManager(){}
		
	void Start () {
        timerDothAppear = gameObject.transform.GetComponent<TimerDothAppear>();
    }
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

    public void EndChallenge(bool success){
        if(pendingChallenge == null){
            return;
        }
        else{
            if(success){
                spotNameThatShouldHaveToken = pendingChallenge.Spot.Name;
            }
            else{
                if(GetSpotsManager() != null) spotsManager.UpdateTokens = true;
                else updateTokens = true;
            }
            pendingChallenge.Success = success;
            pendingChallenge.SaveAsync();
        }
    }

    private SpotsManager GetSpotsManager(){
        if(spotsManager == null){
            GameObject spotsManagerObject = GameObject.Find("SpotsManager");
            if(spotsManagerObject == null){
                return null;
            }
            spotsManager = spotsManagerObject.GetComponent<SpotsManager>();
        }
        return spotsManager;
    }

    public bool HasToken(string spotName){
        return spotName != null && spotName.Equals(spotNameThatShouldHaveToken);
    }

    public bool UpdateTokens(){
        bool returnValue = updateTokens;
        updateTokens = false;
        return returnValue;
    }
    
    public void EndGame(){
        timerDothAppear.Countdown = true;
    }
}
