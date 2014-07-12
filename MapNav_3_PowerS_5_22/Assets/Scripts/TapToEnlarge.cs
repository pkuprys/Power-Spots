using UnityEngine;
using System.Collections;

public class TapToEnlarge : MonoBehaviour {

		float myOriginalX;
		float myOriginalY;
		float myOriginalZ;
		float myScaleX;
		float myScaleY;
		float myScaleZ;
		public static bool cardOut;
	public float enlargeMultiplier = 2.5f;

		void Start(){
				myOriginalX = transform.position.x;
				myOriginalY = transform.position.y;
				myOriginalZ = -4.693985f;

				myScaleX = transform.localScale.x;
				myScaleY = transform.localScale.y;
				myScaleZ = transform.localScale.z;
		}

		int mouseCount;

		void OnMouseDown(){
				mouseCount++;
		if (mouseCount % 2 == 1 && !cardOut) {
						transform.position = new Vector3 (-0.002015591f, 0.8994448f, -6.0f);
			cardOut = true;
			transform.localScale = new Vector3 (this.transform.localScale.x*enlargeMultiplier, this.transform.localScale.y*enlargeMultiplier, 3.25838f);
				} else if (mouseCount % 2 == 0) {
						transform.position = new Vector3 (myOriginalX, myOriginalY, myOriginalZ);
						transform.localScale = new Vector3 (myScaleX, myScaleY, myScaleZ);
			cardOut = false;
				}

		}
}
