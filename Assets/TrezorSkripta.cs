using UnityEngine;
using System.Collections;

public class TrezorSkripta : MonoBehaviour {

	// Use this for initialization
	public bool premakni = false;
	public bool odprt =false;
	public float speed=3;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (premakni) {
			transform.Translate(new Vector3(0,speed*Time.deltaTime,0));
			if(transform.position.y > 7){
				premakni=false;
				odprt = true;
			}
		}
	}
}
