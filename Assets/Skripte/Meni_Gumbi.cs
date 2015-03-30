using UnityEngine;
using System.Collections;


public class Meni_Gumbi : MonoBehaviour {

	// Use this for initialization

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}

	public void newGameButton(){

		Application.LoadLevel ("level6");
	}

	public void highScoreButton(){
		Application.LoadLevel ("HighScoreScena");
	}
}
