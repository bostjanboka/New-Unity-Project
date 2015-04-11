using UnityEngine;
using System.Collections;

public class InputNavigacija : MonoBehaviour {

	// Use this for initialization

	public int level;
	public int trenutniLevel;

	public GameObject zgubil;
	public GameObject zmagal;
	public GameObject back;
	void Start () {
		back.SetActive (false);
		zmagal.SetActive (false);
		zgubil.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Time.timeScale = 0;
			back.SetActive (true);

		}
	
	}

	public void Zgubil(){
		Time.timeScale = 0;
		zgubil.SetActive (true);
	}

	public void Zmagal(){
		Time.timeScale = 0;
		zmagal.SetActive (true);
	}

	public void nastaviNaFalse(){
		back.SetActive (false);
		zmagal.SetActive (false);
		zgubil.SetActive (false);
	}

	public void noviLevel(string level){
		Time.timeScale = 1;
		Application.LoadLevel (level); 
	}

	public void resetLevel(){
		Time.timeScale = 1;
		if (level % 2 == 0) {
			Application.LoadLevel ("level" + level * 2); 
		} else {
			Application.LoadLevel ("level"+(level*2-1+trenutniLevel)); 
		}
		//Application.LoadLevel (Application.loadedLevel); 


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
		StartCoroutine(Wait(Time.timeScale * 3));

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
