using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputNavigacija : MonoBehaviour {

	// Use this for initialization

	public int level;
	public int trenutniLevel;
	public GameObject loading;
	GameObject loadingScreen;
	public GameObject zgubil;
	public GameObject zmagal;
	public GameObject back;

	public Button pavzaGumb;
	public Text cas;
	public Camera cam;

	public GameObject HUD;

	bool pavza=false;

	bool ugasniReklamo=false;

	public static bool zvoki=true;
	float casPavze;

	void Awake(){
		pavzaGumb.gameObject.transform.position = cam.ScreenToWorldPoint(new Vector3(80 ,Screen.height - 100,100));
		cas.gameObject.transform.position = cam.ScreenToWorldPoint(new Vector3(Screen.width-80,Screen.height-80,100));
	}
	void Start () {
		back.SetActive (false);
		zmagal.SetActive (false);
		zgubil.SetActive (false);
		loadingScreen = GameObject.Find ("Loading Logo(Clone)");
		ugasniReklamo=true;
		//Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {

		if ((Input.GetKeyDown (KeyCode.Escape) || pavza) && !zgubil.activeSelf && !zmagal.activeSelf && back.activeSelf) {
			pavza=false;
			contineuGame();
		}
		else if ((Input.GetKeyDown (KeyCode.Escape) || pavza) && !zgubil.activeSelf && !zmagal.activeSelf) {
			Time.timeScale = 0;
			back.SetActive (true);
			pavza=false;

			Move.prizgiReklamo();
			ugasniReklamo=true;
			casPavze=Time.time;
		}
		if (back.activeSelf || zmagal.activeSelf || zgubil.activeSelf) {
			ugasniReklamo=true;
			HUD.SetActive(false);
			OnPressedSkripta.omogocenoPremikanje = false;
		} else {
			OnPressedSkripta.omogocenoPremikanje = true;
			HUD.SetActive(true);
			if(ugasniReklamo){
				Move.ugasniReklamo();
				ugasniReklamo=false;
			}

		}

	
	}

	public void pause(){
		pavza = true;
		casPavze=Time.time;
		Debug.Log ("Pavza");
	}

	public void setHUD(bool active){
		//HUD.SetActive (active);
	}

	public void Zgubil(){
		Time.timeScale = 0;
		zgubil.SetActive (true);
		Move.prizgiReklamo();

	}

	public void Zmagal(){
		Time.timeScale = 0;
		zmagal.SetActive (true);
		Move.prizgiReklamo();

	}

	public void nastaviNaFalse(){
		back.SetActive (false);
		zmagal.SetActive (false);
		zgubil.SetActive (false);
	}

	public void noviLevel(string level2){
		Time.timeScale = 1;
		loadingScreen.GetComponent<LoadingScreen> ().show ();
		LeveliManeger._instance.ponastaviLevel (level+1);
		Application.LoadLevel (level2); 

	}

	public void resetLevel(){
		Time.timeScale = 1;
		Application.LoadLevel( Application.loadedLevel);
	}

	public void quitToMainMenu(){
		Application.LoadLevel ("MeniScena");
		Time.timeScale = 1;
	}

	public void contineuGame(){
		back.SetActive (false);
		zmagal.SetActive (false);
		zgubil.SetActive (false);
		Time.timeScale = .0000001f;
		StartCoroutine(Wait(Time.timeScale * 1.5f));

	}

	IEnumerator Wait(float duration)
	{
		//This is a coroutine
		Debug.Log("Start Wait() function. The time is: "+Time.time);
		Debug.Log( "Float duration = "+duration);
		yield return new WaitForSeconds(duration);   //Wait
		Debug.Log("End Wait() function and the time is: "+Time.time);
		//Move.ugasniReklamo ();
		Time.timeScale = 1;
	} 
}
