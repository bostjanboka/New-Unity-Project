using UnityEngine;
using System.Collections;

public class ScenarijLevela7 : MonoBehaviour {

	public GameObject junak;
	NewBehaviourScript junakSkripta;


	
	
	
	public GameObject prostorZogic;
	public GameObject zmagal;
	public GameObject akcija;
	public GameObject popUpRekord;
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
			LeveliManeger._instance.odkleniStopnjo(8);
			junakSkripta.zmagalLevel();
			LeveliManeger._instance.naredilStopnjo();
			if(LeveliManeger._instance.getCas(7) > junakSkripta.score){
				Instantiate(popUpRekord);
			}else{
				if(Random.value < 0.5f){
					Move.showCelozaslonsko ();
				}
			}

			stanje++;
		}
		
	}
}
