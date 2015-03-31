using UnityEngine;
using System.Collections;


public class Meni_Gumbi : MonoBehaviour {

	// Use this for initialization
	public GameObject loadingScreen;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}

	public void newGameButton(){
		Application.LoadLevel ("level2");
		loadingScreen.GetComponent<LoadingScreen> ().show ();
	}

	public void highScoreButton(){
		Application.LoadLevel ("HighScoreScena");
	}

	IEnumerator Wait(float duration)
	{
		//This is a coroutine
		Debug.Log("Start Wait() function. The time is: "+Time.time);
		Debug.Log( "Float duration = "+duration);
		yield return new WaitForSeconds(duration);   //Wait
		Debug.Log("End Wait() function and the time is: "+Time.time);
		Time.timeScale = 1;

	} 
}
