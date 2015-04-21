using UnityEngine;
using System.Collections;

public class SpiralaScript : MonoBehaviour {

	// Use this for initialization
	public float speed = 5;
	public string vrsta;
	GameObject junak;
	NewBehaviourScript skripta;
	public AudioClip zvok;

	void Awake(){
		if(InputNavigacija.zvoki)
			AudioSource.PlayClipAtPoint(zvok, transform.position);
	}
	void Start () {
		junak = GameObject.Find ("junak1");
	}

	// Update is called once per frame
	void Update () {
		Vector2 move = new Vector2(0,speed)*Time.deltaTime;
		transform.Translate(move);
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
		if (other.gameObject.tag.Equals ("strop")) {
			skripta = junak.GetComponent<NewBehaviourScript>();
			skripta.steviloSpiral--;
			Destroy(gameObject);
			Debug.Log ("noter sem");
		}
	}
}
