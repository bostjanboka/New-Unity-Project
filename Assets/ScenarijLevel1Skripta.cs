using UnityEngine;
using System.Collections;

public class ScenarijLevel1Skripta : MonoBehaviour {

	// Use this for initialization
	public GameObject junak;
	NewBehaviourScript junakSkripta;
	BoxCollider2D coliderJunak;
	public GameObject palcek;
	PalcekAI palcekSkripta;
	public GameObject trezor;
	TrezorSkripta trezorSkripta;
	public GameObject prostorZogic;
	public GameObject akcija;
	SteviloZogicSkripta steviloZogic;


	int stanje;
	void Start () {
		junakSkripta = junak.GetComponent<NewBehaviourScript> ();
		trezorSkripta = trezor.GetComponent<TrezorSkripta> ();
		steviloZogic = prostorZogic.GetComponent<SteviloZogicSkripta> ();
		coliderJunak = junak.GetComponent<BoxCollider2D> ();
		coliderJunak.isTrigger = true;

		junakSkripta.omogociPremikanje = false;

		palcekSkripta = palcek.GetComponent<PalcekAI> ();
		palcekSkripta.xTocka = -3.3f;
		stanje = 0;
		akcija.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (stanje == 0 && palcekSkripta.stojimNaMestuX) {
			trezorSkripta.premakni = true;
			stanje = 1;
		} else if (stanje == 1 && trezorSkripta.odprt) {
			palcekSkripta.xTocka = 15.5f;
			junakSkripta.xTocka = -8f;
			stanje = 2;
		} else if (stanje == 2) {
			if (junakSkripta.stojimNaMestuX) {
				junakSkripta.omogociPremikanje = true;
				coliderJunak.isTrigger = false;
				stanje = 3;
			}
		} else if (stanje == 3) {
			akcija.SetActive (true);
			junakSkripta.meritev=true;
			palcekSkripta.xTocka=21f;
			stanje = 4;
		}else if(stanje == 4 && steviloZogic.prazenProstor){
			junakSkripta.zmagalLevel();
			stanje++;
		}
	}
}
