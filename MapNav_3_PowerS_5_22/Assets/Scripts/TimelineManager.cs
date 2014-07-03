using Parse;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class TimelineManager : MonoBehaviour {
    private static string EVENT_CARD_MODIFIER = "_MODIFIER";
	void Start () {
        StartCoroutine("RenderTimeline");
	}

    private IEnumerator RenderTimeline(){
        var query = new ParseQuery<Team>().FindAsync();
        while(!query.IsCompleted) yield return null;
        IEnumerable<Team> teams = query.Result;
        foreach(Team team in teams){
            GameObject.Find(team.Name + EVENT_CARD_MODIFIER).SetActive(team.IsTextSnippetVisible());
        }
    }
}