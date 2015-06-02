using UnityEngine;
using System.Collections;

public class ClasicZogaSkripta : MonoBehaviour {

	// Use this for initialization komentar  hhh
	public GameObject novaZoga;
	public float visina;
	public float speed;
	public float faktorVisine;
	public float faktorHitrosti;
	public float faktorSkale;
	public float silaSplita;
	public float gravitacija;
	public int ST_del;
	public int smer=1;

	public float rotacija=90;

	public AudioClip pok;

	public float skala;
	Rigidbody2D rb;
	ClasicZogaSkripta clasicSkripta;
	NewBehaviourScript junakSkripta;
	GameObject inst;
	GameObject junak;

	float casOvire;

	void Start () {
		
		rb = transform.parent.GetComponent<Rigidbody2D>();
		junak = GameObject.Find ("junak1");
		skala = transform.parent.gameObject.transform.localScale.x;
		casOvire = -1;
		//smer = 1;
	}
	
	// Update is called once per frame hhhhh
	void Update () {
		Vector2 move = new Vector2(speed*smer,0);
		move *= Time.deltaTime;
		transform.parent.gameObject.transform.Translate(move);

		transform.Rotate (new Vector3(0,0,Time.deltaTime * -rotacija * smer));
		casOvire -= Time.deltaTime;
		if (casOvire < 0) {
			casOvire=-1;
		}

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
			if(casOvire < 0){
				smer *= -1;
				casOvire=1;
			}

		}
		if (other.gameObject.tag.Equals ("spirala")) {
			if(InputNavigacija.zvoki){
				AudioSource.PlayClipAtPoint(pok, transform.position);
			}
			if(novaZoga && ST_del > 0){
				inst = Instantiate (novaZoga, transform.position, Quaternion.identity) as GameObject;
				inst.transform.localScale = inst.transform.localScale * faktorSkale;
				inst.GetComponent<Rigidbody2D>().gravityScale=gravitacija;
				clasicSkripta = inst.transform.GetChild(0).GetComponent<ClasicZogaSkripta>();
				clasicSkripta.skala *= faktorSkale;
				clasicSkripta.visina*=faktorVisine;
				clasicSkripta.speed*=faktorHitrosti;
				clasicSkripta.ST_del--;
				inst.GetComponent<Rigidbody2D>().velocity = new Vector3(0,Mathf.Abs(rb.velocity.y*0.3f)+5,0);


				clasicSkripta.smer = 1;
				
				
				inst = Instantiate (novaZoga, transform.position, Quaternion.identity) as GameObject;
				inst.transform.localScale = inst.transform.localScale * faktorSkale;
				inst.GetComponent<Rigidbody2D>().gravityScale=gravitacija;
				clasicSkripta = inst.transform.GetChild(0).GetComponent<ClasicZogaSkripta>();
				clasicSkripta.skala *= faktorSkale;
				clasicSkripta.visina*=faktorVisine;
				clasicSkripta.speed*=faktorHitrosti;
				clasicSkripta.ST_del--;
				inst.GetComponent<Rigidbody2D>().velocity = new Vector3(0,Mathf.Abs(rb.velocity.y*0.3f)+5,0);
				clasicSkripta.smer = -1;
			}
			
			junakSkripta = junak.GetComponent<NewBehaviourScript>();
			junakSkripta.steviloSpiral--;
			
			Destroy(other.gameObject);
			GameObject parent = gameObject.transform.parent.gameObject;
			Destroy(parent);
		}
		
	}
}
