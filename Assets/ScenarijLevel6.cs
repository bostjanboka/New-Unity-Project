using UnityEngine;
using System.Collections;

public class ScenarijLevel6 : MonoBehaviour {

	// Use this for initialization
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
		palcekSkripta.xTocka = 7f;
		junakSkripta.xTocka = 0f;
		stanje = 0;
		akcija.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (stanje == 0 && palcekSkripta.stojimNaMestuX) {
			stanje = 1;
			Move.ugasniReklamo ();
			akcija.SetActive (true);
			junakSkripta.meritev=true;

			palcekSkripta.xTocka=12f;
			
		}else if(stanje == 1 && steviloZogic.prazenProstor){
			junakSkripta.zmagalLevel();
			stanje++;
		}
		
	}
}
