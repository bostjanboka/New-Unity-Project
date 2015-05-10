using UnityEngine;
using System.Collections;

public class ScenarijLevela9 : MonoBehaviour {

	public GameObject junak;
	NewBehaviourScript junakSkripta;

	public GameObject vrata;
	VrataSkripta vrataSkripta;
	public GameObject akcija;
	public GameObject prostorZogic;
	public GameObject akcija2;
	SteviloZogicSkripta steviloZogic;
	public GameObject newRecord;
	
	float stanje;
	void Start () {
		junakSkripta = junak.GetComponent<NewBehaviourScript> ();
		vrataSkripta = vrata.GetComponent<VrataSkripta> ();
		steviloZogic = prostorZogic.GetComponent<SteviloZogicSkripta> ();
		vrataSkripta.zapri = true;
		
		akcija.SetActive (false);
		akcija2.SetActive (false);
		
		junakSkripta.meritev = true;

		stanje = 0;
	}
	
	// Update is called once per frame
	void Update () {
		

		if (stanje == 0 && vrataSkripta.zaprta) {

			akcija.SetActive (true);
			junakSkripta.meritev=true;
			stanje = 4;
		} else if (stanje == 4 && steviloZogic.prazenProstor) {
			

			vrataSkripta.premakni = true;
			akcija2.SetActive(true);
			stanje = 5;
		} else if (stanje == 5 && vrataSkripta.odprta) {
			stanje = 6;
		} else if (stanje == 6 && steviloZogic.prazenProstor) {
			LeveliManeger._instance.odkleniStopnjo(10);
			junakSkripta.zmagalLevel();
			LeveliManeger._instance.naredilStopnjo();
			if(LeveliManeger._instance.getCas(9) < junakSkripta.score){
				newRecord.SetActive(true);
			}
			stanje++;
			
		}
	}
}
