using UnityEngine;
using System.Collections;

public class skriptaLevel1 : MonoBehaviour {

	// Use this for initialization
	public GameObject junak;
	public GameObject prostorZogic;
	public GameObject akcija;
	public GameObject newRecord;
	public GameObject pressTo;
	public GameObject pressCrta;
	public GameObject holdTo;
	public GameObject holdCrta;

	NewBehaviourScript junakSkripta;
	SteviloZogicSkripta steviloZogic;
	int stanje;
	float cas;
	void Start () {
		junakSkripta = junak.GetComponent<NewBehaviourScript> ();
		junakSkripta.omogociPremikanje = false;
		steviloZogic = prostorZogic.GetComponent<SteviloZogicSkripta> ();
		akcija.SetActive (false);
		akcija.transform.FindChild("ClasicZoga").GetComponent<ClasicZogaSkripta> ().smer = 0;
		stanje = 0;
		junakSkripta.meritev = true;
		pressTo.SetActive (false);
		pressCrta.SetActive (false);
		holdCrta.SetActive (false);
		holdTo.SetActive (false);

		cas = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (stanje == 0) {
			akcija.SetActive (true);
			stanje = 1;
		} else if (stanje == 1 && akcija.transform.position.y < 4) {
			akcija.GetComponent<Rigidbody2D> ().gravityScale = 0;
			akcija.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			stanje = 2;
			pressTo.SetActive (true);
			pressCrta.SetActive(true);
			junakSkripta.meritev = false;

		} else if (stanje == 2) { 
			foreach (Touch touch in Input.touches) {
				
				Vector2 mousePosition = Camera.main.ScreenToWorldPoint (touch.position);
				Collider2D hitCollider = Physics2D.OverlapPoint (mousePosition);
				if (hitCollider.transform.name.Equals ("gumb_strel")) {
					pressTo.SetActive (false);
					pressCrta.SetActive(false);
					stanje = 4;
					junakSkripta.meritev = true;
					junakSkripta.ustreli=true;
					junakSkripta.omogociPremikanje=true;
				}
			}

		} else if (stanje == 4) {
			cas += Time.deltaTime;
			if (cas > 1.5f) {
				stanje = 5;
				holdCrta.SetActive(true);
				holdTo.SetActive (true);
				Time.timeScale=0;
			}

		} else if (stanje == 5) {
			foreach (Touch touch in Input.touches) {
				
				Vector2 mousePosition = Camera.main.ScreenToWorldPoint (touch.position);
				Collider2D hitCollider = Physics2D.OverlapPoint (mousePosition);
				if (hitCollider.transform.name.Equals ("gumb_desno") || hitCollider.transform.name.Equals ("gumb_levo")) {

					holdTo.SetActive (false);
					holdCrta.SetActive(false);
					stanje = 6;
					Time.timeScale=1;
				}
			}
		}else if (stanje == 6 && steviloZogic.prazenProstor) {
			float cs = LeveliManeger._instance.getCas(1);
			LeveliManeger._instance.odkleniStopnjo(2);
			junakSkripta.zmagalLevel();
			LeveliManeger._instance.naredilStopnjo();

			if(cs >= 0 && cs < junakSkripta.score){
				newRecord.SetActive(true);
			}
			stanje++;
		}
	}
}
