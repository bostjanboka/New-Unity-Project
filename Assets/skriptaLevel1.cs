using UnityEngine;
using System.Collections;

public class skriptaLevel1 : MonoBehaviour {

	// Use this for initialization
	public GameObject junak;
	public GameObject prostorZogic;
	public GameObject akcija;

	NewBehaviourScript junakSkripta;
	SteviloZogicSkripta steviloZogic;
	int stanje;
	void Start () {
		junakSkripta = junak.GetComponent<NewBehaviourScript> ();
		steviloZogic = prostorZogic.GetComponent<SteviloZogicSkripta> ();
		akcija.SetActive (false);
		akcija.transform.FindChild("ClasicZoga").GetComponent<ClasicZogaSkripta> ().smer = 0;
		stanje = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (stanje == 0) {
			akcija.SetActive (true);
			stanje = 1;
		} else if (stanje == 1 && akcija.transform.position.y < 4) {
			Time.timeScale= 0;
		}
	}
}
