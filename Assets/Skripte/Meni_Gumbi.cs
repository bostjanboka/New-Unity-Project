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
			if(Application.loadedLevelName.Equals("ZemljevidScena")){
				Application.LoadLevel("MeniScena");
			}else{
				Application.Quit();
			}

		}
	}

	public void naloziZemljevid(){
		Application.LoadLevel ("ZemljevidScena");
	}

	public void naloziMeni(){
		Application.LoadLevel ("MeniScena");
	}

	public void newGameButton(){
		Application.LoadLevel ("level1");
		loadingScreen.GetComponent<LoadingScreen> ().show ();
	}

	public void continueGame(){
		InfoLeveli temp = LeveliManeger._instance.getLevel ();

		if (temp.level == -1) {
			Application.LoadLevel ("ZemljevidScena");
		} else {
			if (temp.level % 2 == 0) {
				Application.LoadLevel ("level" + temp.level * 2); 
			} else {
				Application.LoadLevel ("level"+(temp.level*2-1+temp.trenutniLevel)); 
			}
			loadingScreen.GetComponent<LoadingScreen> ().show ();
		}
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
