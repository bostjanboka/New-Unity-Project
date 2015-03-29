using UnityEngine;
using System.Collections;

public class SteviloZogicSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject vrata;
	public bool prazenProstor;

	VrataSkripta vrataSkripta;
	bool triggered = false;
	int stevilo = 0;
	float time;
	bool trignil;
	void Start () {

		time = Time.time;
		prazenProstor = false;
		trignil = false;
		if (vrata) {
			vrataSkripta = vrata.GetComponent<VrataSkripta> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (triggered) {
			// put exit trigger logic here
			Debug.Log (stevilo);
			time = Time.time;
			prazenProstor=false;
			trignil=true;
		} else if(Time.time - time > 0.5f && trignil == true){
			if(vrata){
				Debug.Log("else"+stevilo);
				vrataSkripta.premakni=true;
			}
			prazenProstor=true;
			Destroy(gameObject);
		}
		stevilo = 0;
		triggered = false;
	}

	void OnTriggerExit2D(Collider2D other){
		Debug.Log ("exit se je zgodil");

	}

	void OnTriggerStay2D( Collider2D other )
	{

		if (other.gameObject.tag.Equals ("zogice")) {
			triggered = true;
			stevilo++;
		}

		// put other enter trigger logic here
	}
}
