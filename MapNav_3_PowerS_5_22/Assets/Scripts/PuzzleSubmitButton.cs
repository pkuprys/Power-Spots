using UnityEngine;
using System.Collections;

public class PuzzleSubmitButton : MonoBehaviour {
    public string answer = "";
		public TextMesh jibberishOBJ;

		public GameObject lineQuad;
		public GameObject circleQuad;

		public Texture redLineTexture;
		public Texture blueLineTexture;

		public Texture blueCircleTexture;

		public TextMesh pressMeText;

		private bool doneGibberish = true;

    void Start () {}
    void Update () {}

    public void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){

						StartCoroutine ("gibberishOutput");

						if(GameObject.Find("Answer_Field").GetComponent<TextInput>().StringToEdit.Equals(answer) && doneGibberish){
								lineQuad.renderer.material.mainTexture = blueLineTexture;
								circleQuad.renderer.material.mainTexture = blueCircleTexture;
								pressMeText.renderer.enabled = true; 

								//GameManager.Instance.EndChallenge(true);
								//Application.LoadLevel("PS_MainMapScene");

            }
        }
    }

		IEnumerator gibberishOutput(){




				yield return doneGibberish = true;
		}
}
