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

	public InputField app42InputNick;

	public Text loginText;
	public Text nickText;


	public static string errorText;


	GameObject mordenLogo;
	GameObject mordenLogo1;
	GameObject gameLogo;
	GameObject singUpLogo;

	GameObject userSer;
	public GameObject gameMusic;
	public GameObject loadingMorden;
	public GameObject loadingMorden1;
	public GameObject loadingGame;
	public GameObject loadingSign;

	public GameObject popUpRate;
	public GameObject user;

	public Toggle musicToggle; 
	public Toggle soundToggle; 

	public static int stKamere=0;
	public Button exit;



	public Button continueGameGumb;

	public Button continueGameMeni;

	public static bool pojdiVMeni=false;
	GameObject zvok;

	bool casNazaj=false;
	void Awake(){
		//PlayerPrefs.DeleteAll ();

		exit.gameObject.transform.position = meni.ScreenToWorldPoint(new Vector3(Screen.width-50,Screen.height-80,100));
		
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

		if (GameObject.Find ("splash_prozoren(Clone)") == null) {
			singUpLogo = Instantiate (loadingSign) as GameObject;

		} else {
			singUpLogo = GameObject.Find ("splash_prozoren(Clone)");
		}

		if (GameObject.Find ("Loading mordenkul 1(Clone)") == null) {
			mordenLogo1 = Instantiate (loadingMorden1) as GameObject;
			mordenLogo1.GetComponent<LoadingScreen>().show();
		} else {
			mordenLogo1 = GameObject.Find ("Loading mordenkul 1(Clone)");
		}

		if (GameObject.Find ("Loading Logo(Clone)") == null) {
			gameLogo = Instantiate (loadingGame) as GameObject;
		} else {
			gameLogo = GameObject.Find ("Loading Logo(Clone)");
		}

		if (!GameObject.Find ("User(Clone)")) {
			userSer = Instantiate (user) as GameObject;
			if (LeveliManeger._instance.getIdUser () == null) {
				stKamere=2;
			}
		} else {
			userSer = GameObject.Find ("User(Clone)");
		}

		musicToggle.isOn = !zvok.GetComponent<DontDestroyOnLoad> ().muzika;


		soundToggle.isOn = !zvok.GetComponent<DontDestroyOnLoad> ().zvok;


		singUpLogo.SetActive (false);


		//zvok.GetComponent<DontDestroyOnLoad> ().muteZvok (!soundToggle.isOn);
		//zvok.GetComponent<DontDestroyOnLoad> ().muteMuzika (!musicToggle.isOn); ss



	}


	public void narediPlayer(){

		nickText.text = "";

		loginText.text = "";
		bool napaka = false;
		if (app42InputNick.text.Length < 4) {
			if (app42InputNick.text.Length < 1) {
				nickText.text = "Please enter nickname";
			} else {
				nickText.text = "Nick must be 4 letters long or more";
			}
			napaka=true;
		} else if (app42InputNick.text.Length > 10) {
			nickText.text = "Nickname is too long, use less than 10 letters";
			napaka=true;
		}

		if (!napaka) {
			userSer.GetComponent<userService> ().updateUser (app42InputNick.text);
			singUpLogo.SetActive(true);

		}

	}


	void Start () {
		if (GameObject.Find ("InputField Input Caret")) {
			GameObject.Find ("InputField Input Caret").SetActive (false);
		}
		popUpRate.SetActive (false);


		kamera(stKamere);
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

		if (input.enabled && singUpLogo.activeSelf) {

			Time.timeScale = 0.0000001f;
		} else if(casNazaj){
			casNazaj=false;
			Time.timeScale=1;
		}
		if (pojdiVMeni) {
			pojdiVMeni=false;
			if(input.enabled){
				kamera(0);
				singUpLogo.SetActive(false);
				casNazaj=true;

			}

		}

		if (errorText != null) {
			string x = errorText;
			string[] y = x.Split(':');
			x = y[y.Length-1];
			x = x.Replace("}","");
			singUpLogo.SetActive(false);
			loginText.text = x;
			if(x.Equals("0 ") || x.Contains("Object reference")){
				pojdiVMeni=true;
			}
		}
	}



	public void facebook(){
		Debug.Log ("OPEN PAGE");
		Application.OpenURL ("https://www.facebook.com/pages/Mordenelf/107340919596875?__mref=message_bubble");

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
		gameLogo.GetComponent<LoadingScreen> ().show ();
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
			mordenLogo.GetComponent<LoadingScreen> ().show ();
		}
	}

	public void gumbRateX(){
		Debug.Log ("gumb rate X");
		popUpRate.SetActive (false);
	}

	public void highScoreButton(){
		userSer.GetComponent<userService> ().getTopNRankings ();
		//Application.LoadLevel ("HighScoreScena");
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
