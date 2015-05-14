using UnityEngine;
using System.Collections;

public class BossKrogla : MonoBehaviour {

	// Use this for initialization komentar  hhh
	public GameObject novaZoga;
	public float visina;
	public float speed;
	public int smer=1;
	
	public float rotacija=90;
	
	public float skala;
	Rigidbody2D rb;
	BossKrogla clasicSkripta;
	NewBehaviourScript junakSkripta;
	GameObject inst;
	GameObject junak;


	Color[] barve;
	int indexBarve;
	public float casZaZamenjatBarvo=1;
	float casTrajanja;
	SpriteRenderer render;


	public AudioClip pok;
	public AudioClip antiPok;
	
	void Start () {
		barve = new Color[10];
		barve [0] = new Color (1,0,0);
		barve [1] = new Color (1,127f/255,0);
		barve [2] = new Color (1,1,0);
		barve [3] = new Color (0,1,0);
		barve [4] = new Color (0,0,1);
		barve [5] = new Color (75f/255,0,130f/255);
		barve [6] = new Color (143f/255,0,1);
		barve [7] = new Color (212f/255,175f/255,52f/255);
		barve [8] = new Color (212f/255,175f/255,52f/255);
		barve [9] = new Color (212f/255,175f/255,52f/255);
		indexBarve = 0;
		casTrajanja = 0;
		rb = transform.parent.GetComponent<Rigidbody2D>();
		junak = GameObject.Find ("junak1");
		skala = transform.parent.gameObject.transform.localScale.x;
		render = gameObject.GetComponent<SpriteRenderer> ();
		render.color = barve [0];


		//smer = 1;
	}
	
	// Update is called once per frame hhhhh
	void Update () {
		casTrajanja += Time.deltaTime;
		if (casTrajanja >= casZaZamenjatBarvo) {
			indexBarve = (++indexBarve)%barve.Length;
			casTrajanja=0;
			render.color = barve[indexBarve];
		}

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

			if(indexBarve <= 6){
				if(novaZoga && skala < 1.7f){
					gameObject.transform.localScale *= 2;
					skala /= 0.5f;
					visina/=0.9f;

				}
				rb.velocity = new Vector3(0,Mathf.Abs(rb.velocity.y*0.5f)+5,0);
				if(InputNavigacija.zvoki){
					AudioSource.PlayClipAtPoint(antiPok, transform.position);
				}

			}else{
				if(novaZoga && skala > 0.13f){
					inst = Instantiate (novaZoga, transform.position, Quaternion.identity) as GameObject;
					inst.transform.localScale = inst.transform.localScale * 0.5f;
					rb = inst.GetComponent<Rigidbody2D>();
					clasicSkripta = inst.transform.GetChild(0).GetComponent<BossKrogla>();
					clasicSkripta.skala *= 0.5f;
					clasicSkripta.visina*=0.9f;
					rb.velocity = new Vector3(0,Mathf.Abs(rb.velocity.y*0.5f)+5,0);
					clasicSkripta.smer = 1;
					
					inst = Instantiate (novaZoga, transform.position, Quaternion.identity) as GameObject;
					inst.transform.localScale = inst.transform.localScale * 0.5f;
					rb = inst.GetComponent<Rigidbody2D>();
					rb.velocity = new Vector3(0,Mathf.Abs(rb.velocity.y*0.5f)+5,0);
					clasicSkripta = inst.transform.GetChild(0).GetComponent<BossKrogla>();
					clasicSkripta.skala *= 0.5f;
					clasicSkripta.smer = -1;
					clasicSkripta.visina*=0.9f;
				}
				if(InputNavigacija.zvoki){
					AudioSource.PlayClipAtPoint(pok, transform.position);
				}
				GameObject parent = gameObject.transform.parent.gameObject;
				Destroy(parent);
			}
			
			junakSkripta = junak.GetComponent<NewBehaviourScript>();
			junakSkripta.steviloSpiral--;
			
			Destroy(other.gameObject);

		}
		
	}
}
