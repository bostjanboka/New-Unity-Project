using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;


public class Meni_Gumbi : MonoBehaviour {

	// Use this for initialization
	public Camera meni;
	public Camera potka;
	public Camera input;
	public Camera scori;


	GameObject loadingScreen;
	GameObject mordenLogo;
	public GameObject gameMusic;
	public GameObject loading;
	public GameObject loadingMorden;

	public GameObject popUpRate;

	public Toggle musicToggle; 
	public Toggle soundToggle; 



	public Button continueGameGumb;

	public Button continueGameMeni;

	GameObject zvok;
	void Awake(){
		PlayGamesPlatform.DebugLogEnabled = true;

		PlayGamesPlatform.Activate();

		zvok = GameObject.Find("game music(Clone)");
		if(zvok == null)
			zvok = Instantiate (gameMusic) as GameObject;
		if (GameObject.Find ("Loading mordenkul(Clone)") == null) {
			mordenLogo = Instantiate (loadingMorden) as GameObject;
			mordenLogo.GetComponent<LoadingScreen>().show();

		} else {
			mordenLogo = GameObject.Find ("Loading mordenkul(Clone)");
		}
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
		Social.localUser.Authenticate((bool success) => {
			// handle success or failure

		});

		kamera(0);
		InfoLeveli temp = LeveliManeger._instance.getLevel ();
		
		if (continueGameGumb && (temp.level == -1 || temp.level % 2 == 0)) {
			continueGameGumb.interactable = false;
		} 

		if (continueGameGumb && temp.level % 2 != 0 && temp.score == 0) {
			continueGameGumb.interactable=false;
		}
		int obiski = LeveliManeger._instance.obiskalIgro ();
		if (continueGameMeni && obiski == 0) {
			continueGameMeni.interactable=false;
		}

		if (LeveliManeger._instance.pokaziRate() == 1 && obiski > 0) {
			popUpRate.SetActive(true);
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(potka.enabled){
				kamera(0);
			}else{
				LeveliManeger._instance.povecajObisk();
				Application.Quit();
			}

		}
	}

	public void facebook(){
		Application.OpenURL ("http://unity3d.com/");

	}

	public void naloziZemljevid(){
		potka.enabled = true;
		meni.enabled = false;
	}

	public void naloziMeni(){
		potka.enabled = false;
		meni.enabled=true;
	}

	public void newGameButton(){
		//Application.LoadLevel ("level1");
		loadingScreen.GetComponent<LoadingScreen> ().show ();
	}

	public void continueGame(){
		InfoLeveli temp = LeveliManeger._instance.getLevel ();

		if ((temp.level == -1 || temp.level % 2 == 0) || temp.level % 2 != 0 && temp.score == 0) {
			kamera(1);
		} else {
			if (temp.level % 2 == 0) {
				Application.LoadLevel ("level" + temp.level * 2); 
			} else {
				Application.LoadLevel ("level"+(temp.level*2-1+temp.trenutniLevel)); 
			}
			loadingScreen.GetComponent<LoadingScreen> ().show ();
		}
	}

	public void gumbRateX(){
		Debug.Log ("gumb rate X");
		popUpRate.SetActive (false);
	}

	public void highScoreButton(){
		Application.LoadLevel ("HighScoreScena");
	}

	public void gumbRate(){
		Move.showRate ();
	}

	public void gumbExit(){
		LeveliManeger._instance.povecajObisk();
		Application.Quit();
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
		InputNavigacija.zvoki = soundToggle.isOn;

	}


	
	public void muteMuzika(){
		zvok.GetComponent<DontDestroyOnLoad> ().muteMuzika (!musicToggle.isOn);

	}

	public void kamera(int i){
		meni.enabled = false;
		potka.enabled = false;
		scori.enabled = false;
		input.enabled = false;
		if (i == 0) {
			meni.enabled = true;
		} else if (i == 1) {
			potka.enabled = true;
		} else if (i == 2) {
			input.enabled = true;
		} else if (i == 3) {
			scori.enabled=true;
		}
	}


}
