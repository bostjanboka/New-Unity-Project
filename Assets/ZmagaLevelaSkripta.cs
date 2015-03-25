using UnityEngine;
using System.Collections;

public class ZmagaLevelaSkripta : MonoBehaviour {

	// Use this for initialization
	public string naloziLevel;
	

	bool triggered = false;
	int stevilo = 0;
	float time;
	void Start () {
		
		time = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
		if (triggered) {
			// put exit trigger logic here
			Debug.Log (stevilo);
			time = Time.time;
		} else if(Time.time - time > 0.2f){
			if(naloziLevel != null){
				Debug.Log("else zmaga levela"+stevilo);
				Application.LoadLevel(naloziLevel);
			}
			//Destroy(gameObject);
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
