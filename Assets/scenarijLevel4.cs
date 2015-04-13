using UnityEngine;
using System.Collections;

public class scenarijLevel4 : MonoBehaviour {

	// Use this for initialization
	public GameObject junak;
	public GameObject palcek;
	public GameObject visenje;
	public GameObject prostorZogic;
	public GameObject zmagal;
	public GameObject caneZaJaw;
	
	
	NewBehaviourScript junakSkripta;
	BoxCollider2D coliderJunak;
	PalcekAI palcekSkripta;
	TrezorSkripta trezorSkripta;
	SteviloZogicSkripta steviloZogic;
	
	
	int stanje;
	void Start () {
		junakSkripta = junak.GetComponent<NewBehaviourScript> ();
		
		steviloZogic = prostorZogic.GetComponent<SteviloZogicSkripta> ();
		coliderJunak = junak.GetComponent<BoxCollider2D> ();
		coliderJunak.isTrigger = true;
		
		junakSkripta.omogociPremikanje = false;
		junakSkripta.xTocka = -8;
		junakSkripta.stojimNaMestuX = false;
		
		palcekSkripta = palcek.GetComponent<PalcekAI> ();
		palcekSkripta.xTocka = 7f;
		stanje = 0;
		caneZaJaw.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (stanje == 0 && junakSkripta.stojimNaMestuX) {
			junakSkripta.omogociPremikanje = true;
			coliderJunak.isTrigger=false;
			stanje = 1;
		} else if (stanje == 1 && palcekSkripta.stojimNaMestuX) {
			palcekSkripta.xTocka = 12.5f;
			visenje.GetComponent<DropDownSkriptaZaVisenje> ().sprozi = true;
			stanje = 2;
		} else if (stanje == 2 && GameObject.FindGameObjectsWithTag ("zogice").Length == 0 && GameObject.FindGameObjectsWithTag ("zeleji").Length == 0) {
			caneZaJaw.SetActive (true);
			stanje=3;
		}
		else if(stanje == 3 && steviloZogic.prazenProstor){
			junakSkripta.zmagalLevel();
			stanje++;
		}
	}
}
