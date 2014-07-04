using Parse;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class TimelineManager : MonoBehaviour {
    private static string REVEAL = "_reveal";
    private static string ONE = "1";
    private static string TWO = "2";

	void Start () {
        StartCoroutine("RenderTimeline");
	}

    private IEnumerator RenderTimeline(){
        var query = new ParseQuery<Team>().FindAsync();
        while(!query.IsCompleted) yield return null;
        IEnumerable<Team> teams = query.Result;
        foreach(Team team in teams){
            GameObject.Find(team.Color + REVEAL + ONE).SetActive(team.IsDayOneCardVisible());
            GameObject.Find(team.Color + REVEAL + TWO).SetActive(team.IsDayTwoCardVisible());
        }
    }
}