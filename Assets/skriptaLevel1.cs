using UnityEngine;
using System.Collections;

public class skriptaLevel1 : MonoBehaviour {

	// Use this for initialization
	public GameObject junak;
	public GameObject prostorZogic;
	public GameObject akcija;

	NewBehaviourScript junakSkripta;
	SteviloZogicSkripta steviloZogic;
	int stanje;
	void Start () {
		junakSkripta = junak.GetComponent<NewBehaviourScript> ();
		steviloZogic = prostorZogic.GetComponent<SteviloZogicSkripta> ();
		akcija.SetActive (false);
		akcija.transform.FindChild("ClasicZoga").GetComponent<ClasicZogaSkripta> ().smer = 0;
		stanje = 0;
		junakSkripta.meritev = true;
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
		} else if (stanje == 2 && steviloZogic.prazenProstor) {
			LeveliManeger._instance.odkleniStopnjo(3);
			junakSkripta.zmagalLevel();
			LeveliManeger._instance.naredilStopnjo();
			if(Random.value < 0.5f){
				Move.showCelozaslonsko ();
			}
			stanje++;
		}
	}
}
