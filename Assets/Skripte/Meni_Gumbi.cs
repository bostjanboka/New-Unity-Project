using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Meni_Gumbi : MonoBehaviour {

	// Use this for initialization
	GameObject loadingScreen;
	public GameObject gameMusic;
	public GameObject loading;

	public Toggle musicToggle; 
	public Toggle soundToggle; 

	GameObject zvok;
	void Awake(){
		zvok = GameObject.Find("game music(Clone)");
		if(zvok == null)
			zvok = Instantiate (gameMusic) as GameObject;
		if (GameObject.Find ("Loading(Clone)") == null) {
			loadingScreen = Instantiate (loading) as GameObject;
		} else {
			loadingScreen = GameObject.Find ("Loading(Clone)");
		}
		musicToggle.isOn = !zvok.GetComponent<DontDestroyOnLoad> ().muzika;

		soundToggle.isOn = !zvok.GetComponent<DontDestroyOnLoad> ().zvok;
		//zvok.GetComponent<DontDestroyOnLoad> ().muteZvok (!soundToggle.isOn);
		//zvok.GetComponent<DontDestroyOnLoad> ().muteMuzika (!musicToggle.isOn);
	}
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

	public void muteZvok(){
		zvok.GetComponent<DontDestroyOnLoad> ().muteZvok (!soundToggle.isOn);
	}
	
	public void muteMuzika(){
		zvok.GetComponent<DontDestroyOnLoad> ().muteMuzika (!musicToggle.isOn);
	}
}
