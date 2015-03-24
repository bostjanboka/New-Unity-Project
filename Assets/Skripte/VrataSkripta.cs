using UnityEngine;
using System.Collections;

public class VrataSkripta : MonoBehaviour {

	// Use this for initialization
	public bool premakni;
	public float speed;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (premakni) {
			Vector3 move = new Vector3(0,speed,0)*Time.deltaTime;
			transform.Translate(move);
			if(transform.position.y > 2.6f){
				premakni = false;
			}
		}
	}
}
