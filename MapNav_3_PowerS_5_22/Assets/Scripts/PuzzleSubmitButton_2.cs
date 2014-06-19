using UnityEngine;
using System.Collections;

public class PuzzleSubmitButton_2 : MonoBehaviour {

	public string answer1 = "123456789";

	public Color c1 = Color.red;
	public Color c2 = Color.yellow;
	public Color c3 = Color.blue;

	public GameObject lineRendererObject_1;

	public GameObject myTextInput;

	public static int correctAnswers = 0;

	public Material red;
	public Material yellow;
	public Material blue;

	void Start () {

		lineRendererObject_1.renderer.material = red;

	}
	void Update () {}

	public void OnMouseOver(){
		if(Input.GetMouseButtonUp(0)){
			if(myTextInput.GetComponent<TextInput>().StringToEdit.Equals(answer1)){
				lineRendererObject_1.renderer.material = yellow;
				correctAnswers++;
				print ("Correct Answers : " + correctAnswers);
			}
		}
	}
}