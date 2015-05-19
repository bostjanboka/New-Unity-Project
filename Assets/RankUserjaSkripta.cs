using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RankUserjaSkripta : MonoBehaviour {

	// Use this for initialization

	void OnGUI() // simply an example of a long ScrollView
	{
		if (userService.playerName != null) {
			gameObject.GetComponent<Text>().text = userService.userRank;
		}
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
