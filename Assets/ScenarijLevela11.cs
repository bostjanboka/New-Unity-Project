using UnityEngine;
using System.Collections;

public class ScenarijLevela11 : MonoBehaviour {

	// Use this for initialization
	public GameObject junak;
	NewBehaviourScript junakSkripta;

	public GameObject palcek;
	PalcekAI palcekSkripta;
	
	
	
	public GameObject prostorZogic;
	SteviloZogicSkripta steviloZogic;
	
	int stanje;
	void Start () {
		junakSkripta = junak.GetComponent<NewBehaviourScript> ();
		
		steviloZogic = prostorZogic.GetComponent<SteviloZogicSkripta> ();

		
		palcekSkripta = palcek.GetComponent<PalcekAI> ();
		palcekSkripta.xTocka = 12.16f;

		stanje = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if(steviloZogic.prazenProstor){
			junakSkripta.zmagalLevel();
			stanje++;
		}
		
	}
}
