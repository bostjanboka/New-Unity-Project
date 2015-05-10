using UnityEngine;
using System.Collections;

public class ScenarijLevela11 : MonoBehaviour {

	// Use this for initialization
	public GameObject junak;
	NewBehaviourScript junakSkripta;

	public GameObject newRecord;

	
	public GameObject prostorZogic;
	SteviloZogicSkripta steviloZogic;
	
	int stanje;
	void Start () {
		junakSkripta = junak.GetComponent<NewBehaviourScript> ();
		
		steviloZogic = prostorZogic.GetComponent<SteviloZogicSkripta> ();


		stanje = 0;
		junakSkripta.meritev=true;
		junakSkripta.strelOmogocen = false;
		Move.ugasniReklamo ();

	}
	
	// Update is called once per frame
	void Update () {
		if(stanje == 0 && steviloZogic.prazenProstor){
			stanje++;
			LeveliManeger._instance.odkleniStopnjo(12);
			junakSkripta.zmagalLevel();
			if(LeveliManeger._instance.getCas(11) < junakSkripta.score){
				newRecord.SetActive(true);
			}
			LeveliManeger._instance.naredilStopnjo();


		}
		
	}
}
