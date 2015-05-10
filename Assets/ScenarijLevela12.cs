using UnityEngine;
using System.Collections;

public class ScenarijLevela12 : MonoBehaviour {

	// Use this for initialization
	public GameObject junak;
	NewBehaviourScript junakSkripta;

	
	
	public GameObject popUpRekord;
	public GameObject prostorZogic;
	public GameObject zmagal;
	public GameObject akcija;
	SteviloZogicSkripta steviloZogic;
	
	int stanje;
	void Start () {
		junakSkripta = junak.GetComponent<NewBehaviourScript> ();
		
		steviloZogic = prostorZogic.GetComponent<SteviloZogicSkripta> ();

		stanje = 0;
		akcija.SetActive (true);
		junakSkripta.meritev=true;
	}
	
	// Update is called once per frame
	void Update () {
		if(stanje == 0 && steviloZogic.prazenProstor){
			junakSkripta.zmagalLevel();
			if(LeveliManeger._instance.getCas(12) < junakSkripta.score){
				Instantiate(popUpRekord);
			}
			LeveliManeger._instance.naredilStopnjo();
			stanje++;
		}
		
	}
}
