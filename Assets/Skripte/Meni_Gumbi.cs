﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class Meni_Gumbi : MonoBehaviour {


	public GameObject meni;
	public GameObject scori;
	public GameObject potka;
	public GameObject input;


	public InputField app42InputNick;

	public Text loginText;
	public Text nickText;


	public static string errorText;


	GameObject mordenLogo;
	GameObject mordenLogo1;
	GameObject gameLogo;
	GameObject singUpLogo;
	GameObject oglasi;

	GameObject userSer;


	public GameObject popUpRate;


	public Toggle musicToggle; 
	public Toggle soundToggle; 

	public static int stKamere=0;
	



	public static bool pojdiVMeni=false;
	GameObject zvok;

	bool casNazaj=false;
	void Awake(){

		oglasi = GameObject.Find ("Oglasi");

		zvok = GameObject.Find("game music");

		mordenLogo = GameObject.Find ("Loading mordenkul");
			
		singUpLogo = GameObject.Find ("splash_prozoren");
			
		gameLogo = GameObject.Find ("Loading Logo");

		userSer = GameObject.Find ("User");
			
		musicToggle.isOn = !zvok.GetComponent<DontDestroyOnLoad> ().muzika;

		soundToggle.isOn = !zvok.GetComponent<DontDestroyOnLoad> ().zvok;

		singUpLogo.SetActive (false);


	}


	public void narediPlayer(){

		nickText.text = "";
		errorText = null;
		loginText.text = "";
		bool napaka = false;
		if (app42InputNick.text.Length < 3) {
			if (app42InputNick.text.Length < 1) {
				nickText.text = "Please enter nickname";
			} else {
				nickText.text = "Nick must be 3 letters long or more";
			}
			napaka = true;
		} else if (app42InputNick.text.Length > 10) {
			nickText.text = "Nickname is too long, use less than 11 letters";
			napaka = true;
		} else if (app42InputNick.text.Contains (" ")) {
			nickText.text = "Nickname must not contain spaces";
			napaka = true;
		}

		if (!napaka) {
			userService.playerX = app42InputNick.text;
			userSer.GetComponent<userService> ().updateUser (app42InputNick.text);
			singUpLogo.SetActive(true);

		}

	}


	void Start () {

		popUpRate.SetActive (false);

		int obiski = LeveliManeger._instance.obiskalIgro ();

		if (LeveliManeger._instance.pokaziRate() == 1 && obiski > 0) {
			popUpRate.SetActive(true);
		}


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(!meni.activeSelf){
				canvas(0);
			}else{
				LeveliManeger._instance.povecajObisk();
				Application.Quit();
			}

		}

		if (input.activeSelf && singUpLogo.activeSelf) {

			Time.timeScale = 0.0000001f;
		} else if(casNazaj){
			casNazaj=false;
			Time.timeScale=1;
		}
		if (pojdiVMeni) {
			pojdiVMeni=false;
			if(input.activeSelf){
				canvas(0);
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
			if(!x.Contains("already exists")){
				pojdiVMeni=true;
			}
		}
	}



	public void facebook(){
		Debug.Log ("OPEN PAGE");
		Application.OpenURL ("https://www.facebook.com/pages/Mordenelf/107340919596875?__mref=message_bubble");

	}

	public void naloziZemljevid(){
		canvas (1);
	}

	public void naloziMeni(){
		canvas (0);
	}

	public void newGameButton(){
		//Application.LoadLevel ("level1");
		gameLogo.GetComponent<LoadingScreen> ().show ();
	}



	public void gumbRateX(){
		popUpRate.SetActive (false);
		LeveliManeger._instance.disableRate ();
	}

	public void highScoreButton(){
		userSer.GetComponent<userService> ().getTopNRankings ();
		//Application.LoadLevel ("HighScoreScena");
	}

	public void gumbRate(){
		Move.showRate ();
		LeveliManeger._instance.disableRate ();
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

	public void canvas(int i){
		meni.SetActive (false);
		potka.SetActive (false);
		scori.SetActive (false);
		input.SetActive (false);
		if (i == 0) {
			meni.SetActive (true);
		} else if (i == 1) {
			potka.SetActive (true);
		} else if (i == 2) {
			input.SetActive (true);
		} else if (i == 3) {
			scori.SetActive (true);
		}
	}


}
