using UnityEngine;
using System.Collections;

public class PalcekAI : MonoBehaviour {

	// Use this for initialization
	public float smer;
	public float speed;
	public float xTocka=1000f;

	public bool stojimNaMestuX=false;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < xTocka) {
			stojimNaMestuX=false;
			transform.Translate (new Vector3 (smer * speed * Time.deltaTime, 0, 0));
		} else {
			stojimNaMestuX = true;
		}

	}
}
