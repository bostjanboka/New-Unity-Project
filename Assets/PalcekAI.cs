using UnityEngine;
using System.Collections;

public class PalcekAI : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	public float smer;
	public float speed;
	public float xTocka=1000f;

	public float palica=1;

	public bool stojimNaMestuX=false;

	void Start () {

		Transform animacija = transform.Find ("palcekAnimacija");

		anim = animacija.gameObject.GetComponent<Animator> ();
		

	}
	
	// Update is called once per frame
	void Update () {

		if (gameObject.transform.position.x < xTocka) {
			stojimNaMestuX=false;
			gameObject.transform.Translate (new Vector3 (smer * speed * Time.deltaTime, 0, 0));

			anim.SetFloat ("odpiranje", 1*palica);

		} else {
			stojimNaMestuX = true;
			anim.SetFloat ("odpiranje", 0*palica);
		}

	}
}
