using UnityEngine;
using System.Collections;

public class DontDestroyOnLoad : MonoBehaviour {


	AudioSource audio;
	GameObject gumbMute;
	GameObject MuzikaMute;
	bool zvok = false;
	bool muzika = false;
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
		audio = gameObject.GetComponent<AudioSource> ();
	}

	public void muteZvok(){
		zvok = !zvok;
		if (zvok) {
			AudioListener.volume = 0;
		} else {
			AudioListener.volume=1;
		}
	}

	public void muteMuzika(){
		muzika = !muzika;
		audio.mute = muzika;
	}
}