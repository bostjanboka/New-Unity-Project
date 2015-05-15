﻿using UnityEngine;
using System.Collections;

public class ScenarijLevel5 : MonoBehaviour {

	// Use this for initialization
	public GameObject junak;
	NewBehaviourScript junakSkripta;

	
	
	public GameObject newRecord;
	public GameObject prostorZogic;
	public GameObject zmagal;
	public GameObject akcija;
	SteviloZogicSkripta steviloZogic;
	
	int stanje;
	void Start () {
		junakSkripta = junak.GetComponent<NewBehaviourScript> ();
		
		steviloZogic = prostorZogic.GetComponent<SteviloZogicSkripta> ();

		stanje = 0;
		akcija.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (stanje == 0) {
			stanje = 1;
			Move.ugasniReklamo ();
			akcija.SetActive (true);
			junakSkripta.meritev=true;
		}else if(stanje == 1 && steviloZogic.prazenProstor){
			LeveliManeger._instance.odkleniStopnjo(6);
			junakSkripta.zmagalLevel();
			LeveliManeger._instance.naredilStopnjo();

			if(LeveliManeger._instance.getCas(5) >= 0 && LeveliManeger._instance.getCas(5) < junakSkripta.score){
				newRecord.SetActive(true);
			}
			stanje++;
			//Time.timeScale=0;
		}
		
	}
}
