﻿using UnityEngine;
using System.Collections;

public class scenarijLevel3 : MonoBehaviour {

	public GameObject junak;
	NewBehaviourScript junakSkripta;
	public GameObject palcek;
	PalcekAI palcekSkripta;
	public GameObject vrata;
	VrataSkripta vrataSkripta;
	public GameObject akcija;
	public GameObject prostorZogic;
	public GameObject zmagal;
	SteviloZogicSkripta steviloZogic;
	
	int stanje;
	void Start () {
		junakSkripta = junak.GetComponent<NewBehaviourScript> ();
		vrataSkripta = vrata.GetComponent<VrataSkripta> ();
		steviloZogic = prostorZogic.GetComponent<SteviloZogicSkripta> ();
		vrataSkripta.zapri = true;

		akcija.SetActive (false);

		
		palcekSkripta = palcek.GetComponent<PalcekAI> ();
		palcekSkripta.xTocka = 3.5f;
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
			palcekSkripta.xTocka = 7;
			stanje = 2;
			Debug.Log ("stanje 1");
		} else if (palcekSkripta.stojimNaMestuX && stanje == 2) {
			if (vrataSkripta.zapri == false && vrataSkripta.zaprta == false) {
				vrataSkripta.zapri = true;
				stanje = 3;
				Debug.Log ("zapiram vrata");
				
			}
		} else if (stanje == 3 && vrataSkripta.zaprta) {
			akcija.SetActive (true);

			stanje = 4;
		} else if (stanje == 4 && steviloZogic.prazenProstor) {
			
			palcekSkripta.xTocka = 12;
			vrataSkripta.premakni = true;
			steviloZogic.upostevajJaw=true;
			stanje = 5;
		}else if(stanje==5 && vrataSkripta.odprta){
			stanje = 6;
		} else if (stanje == 6 && steviloZogic.prazenProstor) {
			zmagal.SetActive(true);
			Time.timeScale=0;
			
		}
		
	}
}