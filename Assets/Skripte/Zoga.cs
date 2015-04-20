using UnityEngine;
using System.Collections;

public class Zoga : MonoBehaviour {

	// Use this for initialization komentar  hhh
	public GameObject novaZoga;
	public int visina;
	public int speed;
	public int smer=1;
	public AudioClip pok;


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
		Vector2 move = new Vector2(speed*smer,0);
		move *= Time.deltaTime;
		transform.Translate(move);
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("noter sem zoga");
		if (other.gameObject.name.Equals ("tla")) {
			rb.velocity = new Vector3 (0, visina);

		} else if (other.gameObject.tag.Equals ("strop")) {
			rb.velocity = new Vector3(0,-Mathf.Abs(rb.velocity.y));
		}
		if (other.gameObject.name.Equals ("Levo")) {
			smer = 1;
		} else if (other.gameObject.name.Equals ("Desno")) {
			smer = -1;
		}else if (other.gameObject.tag.Equals ("ovira")) {
			//rb.velocity = new Vector3(0,-rb.velocity.y*0.5f);
			smer *= -1;
		}
		if (other.gameObject.tag.Equals ("spirala")) {

			AudioSource.PlayClipAtPoint(pok, transform.position);
			if(novaZoga){
				inst = Instantiate (novaZoga, transform.position, Quaternion.identity) as GameObject;
				rb = inst.GetComponent<Rigidbody2D>();
				rb.velocity = new Vector3(0,10);
				zogaSkripta = inst.GetComponent<Zoga>();
				zogaSkripta.smer = 1;


				inst = Instantiate (novaZoga, transform.position, Quaternion.identity) as GameObject;
				rb = inst.GetComponent<Rigidbody2D>();
				rb.velocity = new Vector3(0,10);
				zogaSkripta = inst.GetComponent<Zoga>();
				zogaSkripta.smer = -1;
			}

			junakSkripta = junak.GetComponent<NewBehaviourScript>();
			junakSkripta.steviloSpiral--;

			Destroy(other.gameObject);
			Destroy(gameObject);
		}

	}
}
