using UnityEngine;
using System.Collections;

public class ScenarijLevel2 : MonoBehaviour {

	// Use this for initialization
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

		
		junakSkripta.omogociPremikanje = true;
		

		junakSkripta.xTocka = -8f;
		stanje = 0;


	}
	
	// Update is called once per frame
	void Update () {
		if (stanje == 0) {
			akcija.SetActive (true);
			junakSkripta.meritev=true;
			stanje=1;

		}else if(stanje == 1 && steviloZogic.prazenProstor){
			float cs = LeveliManeger._instance.getCas(2);
			LeveliManeger._instance.odkleniStopnjo(3);
			junakSkripta.zmagalLevel();
			LeveliManeger._instance.naredilStopnjo();
			if(cs >= 0 && cs <  junakSkripta.score){
				newRecord.SetActive(true);
			}
			stanje++;
		}
	
	}
}
