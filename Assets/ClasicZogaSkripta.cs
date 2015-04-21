using UnityEngine;
using System.Collections;

public class ClasicZogaSkripta : MonoBehaviour {

	// Use this for initialization komentar  hhh
	public GameObject novaZoga;
	public float visina;
	public float speed;
	public int smer=1;

	public float rotacija=90;

	public AudioClip pok;

	public float skala;
	Rigidbody2D rb;
	ClasicZogaSkripta clasicSkripta;
	NewBehaviourScript junakSkripta;
	GameObject inst;
	GameObject junak;



	void Start () {
		
		rb = transform.parent.GetComponent<Rigidbody2D>();
		junak = GameObject.Find ("junak1");
		skala = transform.parent.gameObject.transform.localScale.x;
		//smer = 1;
	}
	
	// Update is called once per frame hhhhh
	void Update () {
		Vector2 move = new Vector2(speed*smer,0);
		move *= Time.deltaTime;
		transform.parent.gameObject.transform.Translate(move);

		transform.Rotate (new Vector3(0,0,Time.deltaTime * -rotacija * smer));


	}
	
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("noter sem zoga");
		if (other.gameObject.name.Equals ("tla")) {
			rb.velocity = new Vector3 (0, visina);
			Debug.Log("dotik tal!!!");
			
		} else if (other.gameObject.tag.Equals ("strop")) {
			rb.velocity = new Vector3(0,-Mathf.Abs(rb.velocity.y));
		}
		if (other.gameObject.name.Equals ("Levo")) {
			smer = 1;
		} else if (other.gameObject.name.Equals ("Desno")) {
			smer = -1;
		} else if (other.gameObject.tag.Equals ("ovira")) {
			//rb.velocity = new Vector3(0,-rb.velocity.y*0.5f);
			smer *= -1;
		}
		if (other.gameObject.tag.Equals ("spirala")) {
			if(InputNavigacija.zvoki){
				AudioSource.PlayClipAtPoint(pok, transform.position);
			}
			if(novaZoga && skala > 0.15f){
				inst = Instantiate (novaZoga, transform.position, Quaternion.identity) as GameObject;
				inst.transform.localScale = inst.transform.localScale * 0.5f;
				rb = inst.GetComponent<Rigidbody2D>();
				clasicSkripta = inst.transform.GetChild(0).GetComponent<ClasicZogaSkripta>();
				clasicSkripta.skala *= 0.5f;
				clasicSkripta.visina*=0.9f;
				rb.velocity = new Vector3(0,5);
				clasicSkripta.smer = 1;
				
				
				inst = Instantiate (novaZoga, transform.position, Quaternion.identity) as GameObject;
				inst.transform.localScale = inst.transform.localScale * 0.5f;
				rb = inst.GetComponent<Rigidbody2D>();
				rb.velocity = new Vector3(0,5);
				clasicSkripta = inst.transform.GetChild(0).GetComponent<ClasicZogaSkripta>();
				clasicSkripta.skala *= 0.5f;
				clasicSkripta.smer = -1;
				clasicSkripta.visina*=0.9f;
			}
			
			junakSkripta = junak.GetComponent<NewBehaviourScript>();
			junakSkripta.steviloSpiral--;
			
			Destroy(other.gameObject);
			GameObject parent = gameObject.transform.parent.gameObject;
			Destroy(parent);
		}
		
	}
}
