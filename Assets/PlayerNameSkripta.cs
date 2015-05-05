using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerNameSkripta : MonoBehaviour {

	// Use this for initialization


	void OnGUI() // simply an example of a long ScrollView
	{
		if (userService.playerName != null) {
			gameObject.GetComponent<Text>().text = userService.playerName;
		}
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
