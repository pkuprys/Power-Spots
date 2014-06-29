using Parse;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class SpotsManager : MonoBehaviour {
    private static string SPOT = "_spot";
    private Dictionary<string, GameObject> mapSpots = new Dictionary<string, GameObject>(GameConstants.SPOT_COUNT);
    private Dictionary<string, Spot> spots = new Dictionary<string, Spot>(GameConstants.SPOT_COUNT);
    private DateTime? lastUpdatedTime;

    public GameObject Token;

	void Start () {
        StartCoroutine("RenderSpots");
	}
	void Update () {}

    
    public Spot GetSpot(string name){
        Spot spot;
        spots.TryGetValue(name, out spot);
        return spot;
    }

    public GameObject GetMapSpot(string name){
        GameObject mapSpot;
        mapSpots.TryGetValue(name, out mapSpot);
        return mapSpot;
    }

    private IEnumerator RenderSpots(){
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
            updateOwner(mapSpot, owner);
        }
        StartCoroutine("UpdateSpots");
    }
    //TODO see if the duplicate code in the above and below methods can be reused
    //the problem is that Parse will return errors if we try to do concurrent reads from the same running app
    private IEnumerator UpdateSpots(){
        yield return null;
        while(true){
            yield return new WaitForSeconds(GameConstants.POLL_INTERVAL);
            var query = new ParseQuery<Spot>().WhereGreaterThan("updatedAt", lastUpdatedTime).FindAsync();
            while(!query.IsCompleted) yield return null;
            IEnumerable<Spot> updatedSpots = query.Result;
            foreach(Spot spot in updatedSpots){
                GameObject mapSpot;
                mapSpots.TryGetValue(spot.Name, out mapSpot);
                lastUpdatedTime = ParseUtil.GetLatestTime(spot, lastUpdatedTime);
                Team owner = spot.Owner;
                if(owner == null){
                    continue;
                }
                Task<Team> fetchTask = owner.FetchAsync();
                while(!fetchTask.IsCompleted) yield return null;
                updateOwner(mapSpot, owner);
            }
        }
    }

    public void updateOwner(GameObject mapSpot, Team owner) {
        string coloredSpotName = "Spots/" + owner.Color + SPOT;
        Texture texture = Resources.Load(coloredSpotName, typeof(Texture)) as Texture;
        mapSpot.renderer.material.mainTexture = texture;
        if(owner.ObjectId.Equals(LoginManager.Instance.GetSelectedTeam().ObjectId) && GameManager.Instance.HasToken(mapSpot.gameObject.name)){
            Instantiate(Token, mapSpot.transform.position + new Vector3(0f,0f,0.75f), Quaternion.identity);
        }
    }
}
