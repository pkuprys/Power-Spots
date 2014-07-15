using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public double timeOn = 0.1;
	double timeOff = 0.5;
	private double changeTime = 0;

	void Update() {
		if (Time.time > changeTime) {
			light.enabled = !light.enabled;
			if (light.enabled) {
				changeTime = Time.time + timeOn;
			} else {
				changeTime = Time.time + timeOff;
			}
		}
	}
}
