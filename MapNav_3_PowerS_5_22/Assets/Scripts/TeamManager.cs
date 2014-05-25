using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parse;

public class TeamManager : Singleton<TeamManager> {

	
	protected TeamManager(){}
		
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

//    public IEnumerator InitStatus(){
//        yield return null;
//        foreach(Team team in GetTeams()){
//            if(team.IsSignedIn){
//                readyTeamsCount++;
//            }
//        }
//        StartCoroutine(CheckStatus());
        //do we need to call init from here to avoid concurrent calls to Parse?
        // StartCoroutine(GameManager.Instance.InitStatus());
//	}
	
//	private IEnumerator CheckStatus(){
//	    while(true){
//	        yield return new WaitForSeconds(1f);
//            foreach(Team team in teams){
//                if(!"available".Equals(color.Get<string>("team"))){
//                    AddTeamStatus(color.Get<string>("name"), ParseUtil.GetColor(color));
//                    GameManager.Instance.DisableButton(color.ObjectId);
//                }
//            }
//			foreach(Team team in results){
//				if(!"available".Equals(color.Get<string>("team"))){
//					AddTeamStatus(color.Get<string>("name"), ParseUtil.GetColor(color));
//					GameManager.Instance.DisableButton(color.ObjectId);
//				}
//			}
//		}
//	}
	
//	public void SubmitColorSelection(){
//		ParseObject color = GameManager.Instance.GetCurrentSelection().ParseObject;
//		string teamColor = color.Get<string>("name");
//		color["team"] = teamColor;
//		var save = color.SaveAsync();
//		if(!save.IsFaulted){
//			StartCoroutine(DisableButtons());
//			StartCoroutine(WaitForOtherTeamsOrStartGame());
//		}
//		else{
//			Debug.Log("Could not claim color: " + save.Exception.Message);	
//		}
//	}
	
	private IEnumerator WaitForOtherTeamsOrStartGame(){
        while(1 < GameManager.TEAM_COUNT) yield return null;

//        while(GameManager.readyTeamsCount < GameManager.TEAM_COUNT) yield return null;
		//If the selection manager is never used it can result in a null pointer exception in the next scene,
		//so make sure to instantiate it here to prevent that from happening
		Application.LoadLevel("ColoringSpots");
	}
	
//	public void ResetTeamSelections(){
//		GameObject[] buttons = GameManager.Instance.GetAllButtons();
//		foreach(GameObject go in buttons){
//			ParseObject color = go.GetComponent<TeamButton>().ParseObject;
//			color["team"] = "reset";
//			color.SaveAsync();
//		}
//	}
}
