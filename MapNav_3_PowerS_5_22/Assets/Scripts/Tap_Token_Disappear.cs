using UnityEngine;
using System.Collections;

public class Tap_Token_Disappear : MonoBehaviour {
	public Transform poof;
	private Transform prefabInstance;
	public Texture teamColorParticleTexture;
    public SpotsManager spotsManager;

	void Start(){
		Team team = LoginManager.Instance.GetSelectedTeam();
		teamColorParticleTexture = Resources.Load("hexSpots/" + team.Color + GameConstants.COLOR_SUFFIX, typeof(Texture)) as Texture;

		spotsManager = GameObject.Find ("SpotsManager").GetComponent<SpotsManager> ();
	}

	void OnMouseDown(){
		print ("We have clicked the prefab.");
		poof.renderer.material.mainTexture = teamColorParticleTexture;
		renderer.material.shader = Shader.Find("Unlit/Transparent");
		prefabInstance = Instantiate(poof, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity) as Transform;
		this.renderer.enabled = false;
        spotsManager.UpdateTokens = true;
		Destroy (this, 2.0f);
	}
}
