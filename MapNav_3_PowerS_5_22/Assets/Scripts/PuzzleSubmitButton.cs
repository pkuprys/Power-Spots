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
		public TextMesh gibberishTextOBJ;

		//don't need to specify that it's false on declaration. When unspecified system sets int and float to 0, and bool to false. 

		bool triggeredRandomText = false;
		bool removeLetterOne = false;
		bool triggeredTimer = false;
		int updates;
		string randomText;
		char randomChar1;
		char randomChar2;
		char randomChar3;
		char randomChar4;
		char randomChar5;
		char randomChar6;
		char randomChar7;
		char randomChar8;
		char randomChar9;
		bool startGibberish;

		private bool doneGibberish = true;

	public static bool puzzleSolvEd;

		void OnAwake () {

				puzzleSolvEd = false;

		}
    void Update () {

				updates++;
				if(startGibberish)
				{
						triggeredRandomText = true;
						if(triggeredTimer == false)
						{
								StartCoroutine(TimerToBlue());
								triggeredTimer = true;
						}
				}
				if(triggeredRandomText == true && updates >= 5)
				{
						randomChar1 = System.Convert.ToChar(Random.Range(32,127));
						randomChar2 = System.Convert.ToChar(Random.Range(32,127));
						randomChar3 = System.Convert.ToChar(Random.Range(32,127));
						randomChar4 = System.Convert.ToChar(Random.Range(32,127));
						randomChar5 = System.Convert.ToChar(Random.Range(32,127));
						randomChar6 = System.Convert.ToChar(Random.Range(32,127));
						randomChar7 = System.Convert.ToChar(Random.Range(32,127));
						randomChar8 = System.Convert.ToChar(Random.Range(32,127));
						randomChar9 = System.Convert.ToChar(Random.Range(32,127));
						gibberishTextOBJ.text = randomChar1.ToString() + randomChar2.ToString() + randomChar3.ToString() + randomChar4.ToString() + randomChar5.ToString() + randomChar6.ToString() + randomChar7.ToString() + randomChar8.ToString() + randomChar9.ToString();
						updates = 0;
				}
		}

    public void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
			//StartCoroutine ("gibberishOutput");
			startGibberish = true; 
            StartCoroutine(GameManager.Instance.EndChallenge(true));
			Application.LoadLevel("PS_MainMapScene");
        }
    }

		IEnumerator TimerToBlue () {


				yield return new WaitForSeconds (5);
				if (GameObject.Find ("Answer_Field").GetComponent<TextInput> ().StringToEdit.Equals (answer)) {
						lineQuad.renderer.material.mainTexture = blueLineTexture;
						circleQuad.renderer.material.mainTexture = blueCircleTexture;
						pressMeText.renderer.enabled = true; 
						puzzleSolvEd = true;
				}
				startGibberish = !startGibberish;
				triggeredRandomText = false;
				triggeredTimer = false;
		}
}
