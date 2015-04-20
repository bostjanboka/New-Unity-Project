using UnityEngine;
using System.Collections;

public class PopUpSkripta : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void rateKlik(){
		Move.showRate ();
		Destroy (gameObject);
	}

	public void cancel(){
		Destroy (gameObject);
	}
}
