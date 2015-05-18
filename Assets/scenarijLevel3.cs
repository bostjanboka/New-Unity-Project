using UnityEngine;
using System.Collections;

public class scenarijLevel3 : MonoBehaviour {

	public GameObject junak;
	NewBehaviourScript junakSkripta;

	public GameObject vrata;
	VrataSkripta vrataSkripta;
	public GameObject akcija;
	public GameObject prostorZogic;
	public GameObject zmagal;
	public GameObject newRecord;


	SteviloZogicSkripta steviloZogic;
	
	int stanje;
	void Start () {
		junakSkripta = junak.GetComponent<NewBehaviourScript> ();
		vrataSkripta = vrata.GetComponent<VrataSkripta> ();
		steviloZogic = prostorZogic.GetComponent<SteviloZogicSkripta> ();
		vrataSkripta.zapri = true;

		akcija.SetActive (false);

		

		stanje = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (stanje == 0) {
			akcija.SetActive(true);
			junakSkripta.meritev=true;
			stanje=4;
		
		} else if (stanje == 4 && steviloZogic.prazenProstor) {
			

			vrataSkripta.premakni = true;
			steviloZogic.upostevajJaw=true;
			stanje = 5;
		}else if(stanje==5 && vrataSkripta.odprta){
			stanje = 6;
		} else if (stanje == 6 && steviloZogic.prazenProstor) {
			float cs = LeveliManeger._instance.getCas(3);
			LeveliManeger._instance.odkleniStopnjo(4);
			junakSkripta.zmagalLevel();
			LeveliManeger._instance.naredilStopnjo();
			if(cs >= 0 && cs <  junakSkripta.score){
				newRecord.SetActive(true);
			}

			stanje++;
			
		}
		
	}
}
