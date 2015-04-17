using UnityEngine;
using System.Collections;

public class ScenarijLevela9 : MonoBehaviour {

	public GameObject junak;
	NewBehaviourScript junakSkripta;
	public GameObject palcek;
	PalcekAI palcekSkripta;
	public GameObject vrata;
	VrataSkripta vrataSkripta;
	public GameObject akcija;
	public GameObject prostorZogic;
	public GameObject akcija2;
	SteviloZogicSkripta steviloZogic;
	
	float stanje;
	void Start () {
		junakSkripta = junak.GetComponent<NewBehaviourScript> ();
		vrataSkripta = vrata.GetComponent<VrataSkripta> ();
		steviloZogic = prostorZogic.GetComponent<SteviloZogicSkripta> ();
		vrataSkripta.zapri = true;
		
		akcija.SetActive (false);
		akcija2.SetActive (false);
		
		
		palcekSkripta = palcek.GetComponent<PalcekAI> ();
		palcekSkripta.xTocka = -1.6f;
		stanje = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (palcekSkripta.stojimNaMestuX && stanje == 0) {
			if (vrataSkripta.premakni == false && vrataSkripta.odprta == false) {
				vrataSkripta.premakni = true;
				Debug.Log ("odpiram vrata");
				stanje = 1;
			}
		} else if (stanje == 1 && vrataSkripta.odprta) {
			palcekSkripta.xTocka = 1f;
			stanje = 2;
			Debug.Log ("stanje 1");
		} else if (palcekSkripta.stojimNaMestuX && stanje == 2) {
			if (vrataSkripta.zapri == false && vrataSkripta.zaprta == false) {
				vrataSkripta.zapri = true;
				stanje = 3;
				Debug.Log ("zapiram vrata");
				palcekSkripta.xTocka = 4.5f;
				
			}
		} 
		else if (stanje == 3 && vrataSkripta.zaprta) {
			Move.ugasniReklamo ();
			akcija.SetActive (true);
			junakSkripta.meritev=true;
			stanje = 4;
		} else if (stanje == 4 && steviloZogic.prazenProstor) {
			
			palcekSkripta.xTocka = 12;
			vrataSkripta.premakni = true;
			akcija2.SetActive(true);
			stanje = 5;
		} else if (stanje == 5 && vrataSkripta.odprta) {
			stanje = 6;
		} else if (stanje == 6 && steviloZogic.prazenProstor) {
			junakSkripta.zmagalLevel ();
			stanje++;
			
		}
	}
}
