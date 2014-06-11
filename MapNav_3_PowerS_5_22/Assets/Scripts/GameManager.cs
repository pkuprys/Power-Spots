using Parse;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
    private DateTime? lastUpdatedTime;

    private Challenge pendingChallenge;
	
    protected GameManager(){}
		
	void Start () {}

    void Update () {}

    public IEnumerator Challenge(string spotName){
        GameObject spotsManagerObject = GameObject.Find("SpotsManager");
        SpotsManager spotsManager = spotsManagerObject.GetComponent<SpotsManager>();
        Spot spot = spotsManager.GetSpot(spotName);
        Team team = LoginManager.Instance.GetSelectedTeam();
        pendingChallenge = new Challenge(team, spot);
        var save = pendingChallenge.SaveAsync();
        while(!save.IsCompleted) yield return null;
        if(save.IsFaulted || save.IsCanceled){
            pendingChallenge = null;
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
        pendingChallenge.Success = success;
        pendingChallenge.SaveAsync();
    }
}
