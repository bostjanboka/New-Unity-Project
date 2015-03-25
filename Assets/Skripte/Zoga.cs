using UnityEngine;
using System.Collections;

public class Zoga : MonoBehaviour {

	// Use this for initialization komentar  hhh
	public GameObject novaZoga;
	public int visina;
	public int speed;


	Rigidbody2D rb;
	Zoga zogaSkripta;
	NewBehaviourScript junakSkripta;
	GameObject inst;
	GameObject junak;
	void Start () {

		rb = GetComponent<Rigidbody2D>();
		junak = GameObject.Find ("junak1");
	}
	
	// Update is called once per frame hhhhh
	void Update () {
		Vector2 move = new Vector2(speed,0);
		move *= Time.deltaTime;
		transform.Translate(move);
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("noter sem zoga");
		if (other.gameObject.name.Equals ("tla")) {
			rb.velocity = new Vector3(0,visina);

		}
		if (other.gameObject.name.Equals ("Cube") || other.gameObject.name.Equals ("Cube 1") || other.gameObject.name.Equals("steber")) {
			speed *= -1;
		}
		if (other.gameObject.tag.Equals ("spirala")) {


			if(novaZoga){
				inst = Instantiate (novaZoga, transform.position, Quaternion.identity) as GameObject;
				rb = inst.GetComponent<Rigidbody2D>();
				rb.velocity = new Vector3(0,10);


				inst = Instantiate (novaZoga, transform.position, Quaternion.identity) as GameObject;
				rb = inst.GetComponent<Rigidbody2D>();
				rb.velocity = new Vector3(0,10);
				zogaSkripta = inst.GetComponent<Zoga>();
				zogaSkripta.speed *= -1;
			}

			junakSkripta = junak.GetComponent<NewBehaviourScript>();
			junakSkripta.steviloSpiral--;

			Destroy(other.gameObject);
			Destroy(gameObject);
		}

	}
}
