using UnityEngine;
using System.Collections;

public class VisenjeSkripta : MonoBehaviour {

	// Use this for initialization
	public GameObject zoga;
	GameObject junak;
	NewBehaviourScript junakSkripta;
	void Start () {
		junak = GameObject.Find ("junak1");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("deluje triger gor");
		if (other.gameObject.tag.Equals ("spirala")) {
			GameObject inst = Instantiate (zoga, transform.position, Quaternion.identity) as GameObject;
			inst.transform.localScale = gameObject.transform.localScale;
			junakSkripta = junak.GetComponent<NewBehaviourScript>();
			junakSkripta.steviloSpiral--;
			Destroy(gameObject.transform.parent.gameObject);
			Destroy(other.gameObject);
		}
	}
}
