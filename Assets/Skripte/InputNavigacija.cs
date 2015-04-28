using UnityEngine;
using System.Collections;

public class InputNavigacija : MonoBehaviour {

	// Use this for initialization

	public int level;
	public int trenutniLevel;
	public GameObject loading;
	GameObject loadingScreen;
	public GameObject zgubil;
	public GameObject zmagal;
	public GameObject back;

	public GameObject HUD;

	public static bool zvoki=true;
	void Start () {
		back.SetActive (false);
		zmagal.SetActive (false);
		zgubil.SetActive (false);
		loadingScreen = Instantiate (loading) as GameObject;
		//Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) && !zgubil.activeSelf && !zmagal.activeSelf) {
			Time.timeScale = 0;
			back.SetActive (true);

			//Move.prizgiReklamo();
		}
		if (back.activeSelf || zmagal.activeSelf || zgubil.activeSelf) {
			OnPressedSkripta.omogocenoPremikanje = false;
		} else {
			OnPressedSkripta.omogocenoPremikanje = true;
		}

	
	}

	public void setHUD(bool active){
		HUD.SetActive (active);
	}

	public void Zgubil(){
		Time.timeScale = 0;
		zgubil.SetActive (true);
		//Move.prizgiReklamo();

	}

	public void Zmagal(){
		Time.timeScale = 0;
		zmagal.SetActive (true);
		//Move.prizgiReklamo();

	}

	public void nastaviNaFalse(){
		back.SetActive (false);
		zmagal.SetActive (false);
		zgubil.SetActive (false);
	}

	public void noviLevel(string level){
		Time.timeScale = 1;
		loadingScreen.GetComponent<LoadingScreen> ().show ();
		Application.LoadLevel (level); 
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
