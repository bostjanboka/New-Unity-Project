using UnityEngine;
using System.Collections;

public class ScenarijLevela7 : MonoBehaviour {

	public GameObject junak;
	NewBehaviourScript junakSkripta;

	public GameObject palcek;
	PalcekAI palcekSkripta;
	
	
	
	public GameObject prostorZogic;
	public GameObject zmagal;
	public GameObject akcija;
	SteviloZogicSkripta steviloZogic;
	
	int stanje;
	void Start () {
		junakSkripta = junak.GetComponent<NewBehaviourScript> ();
		
		steviloZogic = prostorZogic.GetComponent<SteviloZogicSkripta> ();

		
		palcekSkripta = palcek.GetComponent<PalcekAI> ();
		palcekSkripta.xTocka = 12.16f;

		stanje = 0;
		akcija.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {

			
		if(stanje == 0 && steviloZogic.prazenProstor){
			LeveliManeger._instance.odkleniStopnjo(4);
			junakSkripta.zmagalLevel();
			LeveliManeger._instance.naredilStopnjo();
			stanje++;
		}
		
	}
}
