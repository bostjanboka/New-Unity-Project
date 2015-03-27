using UnityEngine;
using System.Collections;

public class MuteMusic : MonoBehaviour {

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space))
			if (GetComponent<AudioSource>().mute)
				GetComponent<AudioSource>().mute = false;
		else
			GetComponent<AudioSource>().mute = true;
		
	}
}