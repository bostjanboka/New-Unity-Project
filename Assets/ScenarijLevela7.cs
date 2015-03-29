using UnityEngine;
using System.Collections;

public class ScenarijLevela7 : MonoBehaviour {

	// Use this for initialization
	public GameObject junak;
	NewBehaviourScript junakSkripta;
	public GameObject palcek;
	PalcekAI palcekSkripta;
	public GameObject vrata;
	VrataSkripta vrataSkripta;
	public GameObject jawBreaker;
	public GameObject modra;
	public GameObject prostorZogic;
	public GameObject zmagal;
	SteviloZogicSkripta steviloZogic;

	int stanje;
	void Start () {
		junakSkripta = junak.GetComponent<NewBehaviourScript> ();
		vrataSkripta = vrata.GetComponent<VrataSkripta> ();
		steviloZogic = prostorZogic.GetComponent<SteviloZogicSkripta> ();
		vrataSkripta.zapri = true;
		junakSkripta.omogociPremikanje = false;

		modra.SetActive (false);
		jawBreaker.SetActive (false);

		palcekSkripta = palcek.GetComponent<PalcekAI> ();
		palcekSkripta.xTocka = 15;
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
			palcekSkripta.xTocka = 18;
			stanje = 2;
			Debug.Log ("stanje 1");
		} else if (palcekSkripta.stojimNaMestuX && stanje == 2) {
			if (vrataSkripta.zapri == false && vrataSkripta.zaprta == false) {
				vrataSkripta.zapri = true;
				stanje = 3;
				Debug.Log ("zapiram vrata");

			}
		} else if (stanje == 3 && vrataSkripta.zaprta) {
			modra.SetActive (true);
			jawBreaker.SetActive (true);
			junakSkripta.omogociPremikanje = true;
			stanje = 4;
		} else if (stanje == 4 && steviloZogic.prazenProstor) {

			palcekSkripta.xTocka = 22;
			vrataSkripta.premakni = true;
			stanje = 5;
		} else if (palcekSkripta.stojimNaMestuX && stanje == 5) {
			zmagal.SetActive(true);
			Time.timeScale=0;

		}
	
	}
}
