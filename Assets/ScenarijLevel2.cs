using UnityEngine;
using System.Collections;

public class ScenarijLevel2 : MonoBehaviour {

	// Use this for initialization
	public GameObject junak;
	NewBehaviourScript junakSkripta;



	
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
			LeveliManeger._instance.odkleniStopnjo(3);
			junakSkripta.zmagalLevel();
			LeveliManeger._instance.naredilStopnjo();
			if(Random.value < 0.5f){
				//Move.showCelozaslonsko ();
			}
			stanje++;
		}
	
	}
}
