﻿using UnityEngine;
using System.Collections;

public class ScenarijLevela8 : MonoBehaviour {

	// Use this for initialization
	public GameObject junak;
	NewBehaviourScript junakSkripta;
	BoxCollider2D coliderJunak;
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
		palcekSkripta.xTocka = 4.4f;

		stanje = 0;
		akcija.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (stanje == 0 && palcekSkripta.stojimNaMestuX) {
			stanje = 1;
			akcija.SetActive (true);

			palcekSkripta.xTocka=21f;
			
		}else if(stanje == 1 && steviloZogic.prazenProstor){
			junakSkripta.zmagalLevel();
			stanje++;
		}
		
	}
}