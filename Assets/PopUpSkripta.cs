using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUpSkripta : MonoBehaviour {

	// Use this for initialization
	public Toggle dontShow;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void rateKlik(){
		Move.showRate ();
		LeveliManeger._instance.disableRate();
		Destroy (gameObject);
	}

	public void cancel(){
		if (dontShow && dontShow.isOn) {
			LeveliManeger._instance.disableRate();
		}
		Destroy (gameObject);
	}
}
