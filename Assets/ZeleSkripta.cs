using UnityEngine;
using System.Collections;

public class ZeleSkripta : MonoBehaviour {

	// Use this for initialization komentar  hhh
	public GameObject noviZele;
	public int visina;
	public float speed;
	public int smer;
	public int korak;
	
	float stopinje;
	public float skala;
	Rigidbody2D rb;
	ZeleSkripta zeleSkripta;
	NewBehaviourScript junakSkripta;
	GameObject inst;
	GameObject junak;

	public float timeNastanka;
	void Start () {
		
		rb = GetComponent<Rigidbody2D>();
		junak = GameObject.Find ("junak1");
		stopinje = 0;
		skala = transform.localScale.x;
		timeNastanka = Time.time;
		//smer = 1;
	}
	
	// Update is called once per frame hhhhh
	void Update () {
		Vector2 move = new Vector2(speed*smer,0);
		move *= Time.deltaTime;
		transform.Translate(move);
		transform.localScale = new Vector3 (skala, skala*(1 - Mathf.Sin (stopinje * 0.0174532925f) * 0.1f), 1);
		stopinje = (stopinje + korak*Time.deltaTime)%360;
		//stopinje *= Time.deltaTime;
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
		} else if (other.gameObject.tag.Equals ("ovira")) {
			//rb.velocity = new Vector3(0,-rb.velocity.y*0.5f);
			smer *= -1;
		}

		if (other.gameObject.tag.Equals ("zeleji")) {
			Debug.Log("zeleji");
			zeleSkripta = other.gameObject.GetComponent<ZeleSkripta>();
			if(Time.time-timeNastanka > 0.5f && Time.time-zeleSkripta.timeNastanka > 0.5f)
			{
				Debug.Log("zeleji izbris");
				if(skala > zeleSkripta.skala){
					skala += zeleSkripta.skala;
					skala = other.gameObject.transform.localScale.x + transform.localScale.x;
					Destroy(other.gameObject);
				}else{
					zeleSkripta.skala = other.gameObject.transform.localScale.x + transform.localScale.x;
					Destroy(gameObject);
				}
			}
		}

		if (other.gameObject.tag.Equals ("spirala")) {
			
			
			if(noviZele && skala > 0.070f){
				inst = Instantiate (noviZele, transform.position, Quaternion.identity) as GameObject;
				inst.transform.localScale = inst.transform.localScale * 0.5f;
				rb = inst.GetComponent<Rigidbody2D>();
				zeleSkripta = inst.GetComponent<ZeleSkripta>();
				zeleSkripta.skala *= 0.5f;
				rb.velocity = new Vector3(0,5);
				zeleSkripta.smer = 1;
				
				inst = Instantiate (noviZele, transform.position, Quaternion.identity) as GameObject;
				inst.transform.localScale = inst.transform.localScale * 0.5f;
				rb = inst.GetComponent<Rigidbody2D>();
				rb.velocity = new Vector3(0,5);
				zeleSkripta = inst.GetComponent<ZeleSkripta>();
				zeleSkripta.skala *= 0.5f;
				zeleSkripta.smer = -1;
			}
			
			junakSkripta = junak.GetComponent<NewBehaviourScript>();
			junakSkripta.steviloSpiral--;
			
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
		
	}
}
