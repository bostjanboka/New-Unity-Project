using UnityEngine;
using System.Collections;

public class InputNavigacija : MonoBehaviour {

	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void noviLevel(string level){

	}

	public void resetLevel(){
		Application.LoadLevel ("level10"); 
		Time.timeScale = 1;
	}
}
