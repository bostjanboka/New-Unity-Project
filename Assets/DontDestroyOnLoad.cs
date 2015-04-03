using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DontDestroyOnLoad : MonoBehaviour {


	AudioSource audio;
	GameObject gumbMute;
	GameObject MuzikaMute;
	public bool zvok = false;
	public bool muzika = false;




	void Awake() {

		DontDestroyOnLoad(transform.gameObject);
		audio = gameObject.GetComponent<AudioSource> ();
		audio.mute = true;
	}

	void Start(){
		audio.mute = false;

	}

	void Update(){

	}

	public void muteZvok(bool x){
		zvok = x;
		if (zvok) {
			AudioListener.volume = 0;
		} else {
			AudioListener.volume=1;
		}
	}

	public void muteMuzika(bool x){
		muzika = x;
		audio.mute = muzika;
	}
}