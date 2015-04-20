using UnityEngine;
using System.Collections;

public class ScenarijLevela12 : MonoBehaviour {

	// Use this for initialization
	public GameObject junak;
	NewBehaviourScript junakSkripta;
	public GameObject palcek;
	PalcekAI palcekSkripta;
	
	
	public GameObject popUpRekord;
	public GameObject prostorZogic;
	public GameObject zmagal;
	public GameObject akcija;
	SteviloZogicSkripta steviloZogic;
	
	int stanje;
	void Start () {
		junakSkripta = junak.GetComponent<NewBehaviourScript> ();
		
		steviloZogic = prostorZogic.GetComponent<SteviloZogicSkripta> ();

		
		palcekSkripta = palcek.GetComponent<PalcekAI> ();
		palcekSkripta.xTocka = 0f;
		junakSkripta.xTocka = -8f;
		stanje = 0;
		akcija.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (stanje == 0 && palcekSkripta.stojimNaMestuX) {
			if(palcek.transform.position.y < 1.4f){
				palcek.transform.Translate(new Vector2(0,2*Time.deltaTime));

			}else{
				palcek.SetActive(false);
				Move.ugasniReklamo ();
				akcija.SetActive (true);
				junakSkripta.meritev=true;
				stanje = 1;
			}


			//palcekSkripta.xTocka=21f;
			
		}else if(stanje == 1 && steviloZogic.prazenProstor){
			junakSkripta.zmagalLevel();
			if(LeveliManeger._instance.getCas(1) > junakSkripta.score){
				Instantiate(popUpRekord);
			}
			LeveliManeger._instance.naredilStopnjo();
			stanje++;
		}
		
	}
}
