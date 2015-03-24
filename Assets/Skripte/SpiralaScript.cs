using UnityEngine;
using System.Collections;

public class SpiralaScript : MonoBehaviour {

	// Use this for initialization
	public float speed = 5;
	GameObject junak;
	NewBehaviourScript skripta;
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		Vector2 move = new Vector2(0,speed)*Time.deltaTime;
		transform.Translate(move);
		junak = GameObject.Find ("junak1");
	}

	/*void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.name.Equals ("Cube 2")) {
			Debug.Log("cube 2");
			//DestroyObject(gameObject);
			DestroyImmediate(gameObject);
		}
	}*/
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("noter sem spirala");
		if (other.gameObject.name.Equals ("Cube 2")) {
			skripta = junak.GetComponent<NewBehaviourScript>();
			skripta.steviloSpiral--;
			Destroy(gameObject);
			Debug.Log ("noter sem");
		}
	}
}
