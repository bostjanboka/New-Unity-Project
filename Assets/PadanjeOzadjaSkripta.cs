using UnityEngine;
using System.Collections;

public class PadanjeOzadjaSkripta : MonoBehaviour {

	// Use this for initialization
	public float padanje;
	GameObject junak;
	void Start () {
		junak = GameObject.Find("junak1");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag.Equals ("spirala")) {
			transform.Translate (new Vector3 (0, -padanje, 0));
		} else if (other.gameObject.tag.Equals ("junak")) {
			junak.GetComponent<NewBehaviourScript>().zgubilLevel();
		}
	}


}
