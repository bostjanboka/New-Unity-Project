using UnityEngine;
using System.Collections;

public class JawBreakerSkripta : MonoBehaviour {

	// Use this for initialization komentar  hhh
	public GameObject noviJaw;
	public float visina;
	public float speed;
	public float smer;
	public float silaSplita;

	public AudioClip pok;
	public AudioClip antiPok;

	public float rotacija=90;

	Rigidbody2D rb;
	JawBreakerSkripta jawBreakerSkripta;
	NewBehaviourScript junakSkripta;
	SpiralaScript spirala;
	GameObject inst;
	GameObject junak;
	float casOvire;
	
	public float timeNastanka;
	void Start () {
		
		rb = transform.parent.gameObject.GetComponent<Rigidbody2D>();
		junak = GameObject.Find ("junak1");

		timeNastanka = Time.time;
	}
	
	// Update is called once per frame hhhhh
	void Update () {
		Vector2 move = new Vector2(speed*smer,0);
		move *= Time.deltaTime;
		transform.parent.Translate(move);
		transform.Rotate (new Vector3(0,0,Time.deltaTime * -rotacija * smer));
		//stopinje *= Time.deltaTime;
		casOvire -= Time.deltaTime;
		if (casOvire < 0) {
			casOvire=-1;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("noter sem zoga");
		if (other.gameObject.name.Equals ("tla")) {
			rb.velocity = new Vector3(0,visina);
			
		}
		if (other.gameObject.name.Equals ("Levo")) {
			smer = 1;
		} else if (other.gameObject.name.Equals ("Desno")) {
			smer = -1;
		} else if (other.gameObject.tag.Equals ("ovira")) {
			if(casOvire < 0){
				smer *= -1;
				casOvire=1;
			}
		}

		if (other.gameObject.tag.Equals ("spirala")) {
			
			rb.velocity = new Vector3(0,silaSplita);

			spirala = other.gameObject.GetComponent<SpiralaScript>();


			junakSkripta = junak.GetComponent<NewBehaviourScript>();
			junakSkripta.steviloSpiral--;
			
			Destroy(other.gameObject);
			if(spirala.vrsta.Equals("jaw")){
				if(InputNavigacija.zvoki){
					AudioSource.PlayClipAtPoint(pok, transform.position);
				}
				Destroy(gameObject);
			}else{
				if(InputNavigacija.zvoki){
					AudioSource.PlayClipAtPoint(antiPok, transform.position);
				}
			}
			//
		}
		
	}
}
