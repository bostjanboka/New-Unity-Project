using UnityEngine;
using System.Collections;

public class scenarijLevel4 : MonoBehaviour {

	// Use this for initialization
	public GameObject junak;

	public GameObject visenje;
	public GameObject prostorZogic;
	public GameObject zmagal;
	public GameObject caneZaJaw;

	
	public GameObject newRecord;
	NewBehaviourScript junakSkripta;



	SteviloZogicSkripta steviloZogic;
	
	
	int stanje;
	void Start () {
		junakSkripta = junak.GetComponent<NewBehaviourScript> ();
		
		steviloZogic = prostorZogic.GetComponent<SteviloZogicSkripta> ();

		stanje = 0;
		caneZaJaw.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (stanje == 0) {

			visenje.GetComponent<DropDownSkriptaZaVisenje> ().sprozi = true;
			junakSkripta.meritev=true;
			stanje = 2;
		} else if (stanje == 2 && GameObject.FindGameObjectsWithTag ("zogice").Length == 0 && GameObject.FindGameObjectsWithTag ("zeleji").Length == 0) {
			caneZaJaw.SetActive (true);
			stanje=3;
		}
		else if(stanje == 3 && steviloZogic.prazenProstor){
			LeveliManeger._instance.odkleniStopnjo(5);
			junakSkripta.zmagalLevel();
			LeveliManeger._instance.naredilStopnjo();

			if(LeveliManeger._instance.getCas(4) < junakSkripta.score){
				newRecord.SetActive(true);
			}


			stanje++;
		}
	}
}
