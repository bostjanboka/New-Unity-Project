using UnityEngine;
using System.Collections;

public class JawBreakerSkripta : MonoBehaviour {

	// Use this for initialization komentar  hhh
	public GameObject noviJaw;
	public int visina;
	public int speed;

	

	Rigidbody2D rb;
	JawBreakerSkripta jawBreakerSkripta;
	NewBehaviourScript junakSkripta;
	SpiralaScript spirala;
	GameObject inst;
	GameObject junak;
	
	public float timeNastanka;
	void Start () {
		
		rb = GetComponent<Rigidbody2D>();
		junak = GameObject.Find ("junak1");

		timeNastanka = Time.time;
	}
	
	// Update is called once per frame hhhhh
	void Update () {
		Vector2 move = new Vector2(speed,0);
		move *= Time.deltaTime;
		transform.Translate(move);

		//stopinje *= Time.deltaTime;
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
			
			rb.velocity = new Vector3(0,5);
			/*if(noviZele && skala > 0.070f){
				inst = Instantiate (noviZele, transform.position, Quaternion.identity) as GameObject;
				inst.transform.localScale = inst.transform.localScale * 0.5f;
				rb = inst.GetComponent<Rigidbody2D>();
				zeleSkripta = inst.GetComponent<ZeleSkripta>();
				zeleSkripta.skala *= 0.5f;
				rb.velocity = new Vector3(0,5);
				
				
				inst = Instantiate (noviZele, transform.position, Quaternion.identity) as GameObject;
				inst.transform.localScale = inst.transform.localScale * 0.5f;
				rb = inst.GetComponent<Rigidbody2D>();
				rb.velocity = new Vector3(0,5);
				zeleSkripta = inst.GetComponent<ZeleSkripta>();
				zeleSkripta.skala *= 0.5f;
				zeleSkripta.speed *= -1;
			}*/
			spirala = other.gameObject.GetComponent<SpiralaScript>();


			junakSkripta = junak.GetComponent<NewBehaviourScript>();
			junakSkripta.steviloSpiral--;
			
			Destroy(other.gameObject);
			if(spirala.vrsta.Equals("jaw")){
				Destroy(gameObject);
			}
			//
		}
		
	}
}
