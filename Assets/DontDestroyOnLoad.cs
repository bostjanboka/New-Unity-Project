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
		//audio.mute = true;
		if (PlayerPrefs.HasKey ("zvok") && PlayerPrefs.GetInt ("zvok") == 1) {
			zvok = true;
		}
		
		if (PlayerPrefs.HasKey ("muzika") && PlayerPrefs.GetInt ("muzika") == 1) {
			audio.mute = true;
			muzika = true;
		}
	}

	void Start(){



	}

	void Update(){

	}

	public void muteZvok(bool x){
		zvok = x;
		if (zvok) {
			//AudioListener.volume = 0;
		} else {
			//AudioListener.volume=1;
		}
		if (x) {
			PlayerPrefs.SetInt ("zvok", 1);
		} else {
			PlayerPrefs.SetInt ("zvok", 0);
		}

	}

	public void muteMuzika(bool x){
		muzika = x;
		audio.mute = muzika;
		if (x) {
			PlayerPrefs.SetInt ("muzika", 1);
		} else {
			PlayerPrefs.SetInt ("muzika", 0);
		}
	}
}