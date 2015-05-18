using UnityEngine;
using System.Collections;

public class ScenarijLevela7 : MonoBehaviour {

	public GameObject junak;
	NewBehaviourScript junakSkripta;


	
	public GameObject newRecord;
	
	public GameObject prostorZogic;
	public GameObject zmagal;
	public GameObject akcija;

	SteviloZogicSkripta steviloZogic;
	
	int stanje;
	void Start () {
		junakSkripta = junak.GetComponent<NewBehaviourScript> ();
		
		steviloZogic = prostorZogic.GetComponent<SteviloZogicSkripta> ();

		junakSkripta.meritev = true;
		stanje = 0;
		akcija.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {

			
		if(stanje == 0 && steviloZogic.prazenProstor){
			float cs = LeveliManeger._instance.getCas(7);
			LeveliManeger._instance.odkleniStopnjo(8);
			junakSkripta.zmagalLevel();
			LeveliManeger._instance.naredilStopnjo();
			if(cs >= 0 && cs <  junakSkripta.score){
				newRecord.SetActive(true);
			}

			stanje++;
		}
		
	}
}
