using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PotkaSkripta : MonoBehaviour {

	// Use this for initialization
	public Button ena;
	public Button dve;
	public Button tri;
	public Button stiri;
	public Button pet;
	public Button sest;
	public Button sedem;
	public Button osem;
	public Button devet;
	public Button deset;
	public Button enajst;
	public Button dvanajst;


	public GameObject level1;
	public GameObject level2;
	public GameObject level3;
	public GameObject level4;
	public GameObject level5;
	public GameObject level6;
	public GameObject level7;
	public GameObject level8;
	public GameObject level9;
	public GameObject level10;
	public GameObject level11;
	public GameObject level12;

	public GameObject potkaNavodila;


	public Text totalCas;
	float skupaj;
	GameObject gameLogo;
	void Awake(){
		gameLogo = GameObject.Find ("Loading Logo");
	}

	void Start () {
		level1.SetActive (false);
		level2.SetActive (false);
		level3.SetActive (false);
		level4.SetActive (false);
		level5.SetActive (false);
		level6.SetActive (false);
		level7.SetActive (false);
		level8.SetActive (false);
		level9.SetActive (false);
		level10.SetActive (false);
		level11.SetActive (false);
		level12.SetActive (false);

		//ena.interactable = LeveliManeger._instance.odklenjenaStopnja(1);
		dve.interactable = LeveliManeger._instance.odklenjenaStopnja(2);
		tri.interactable = LeveliManeger._instance.odklenjenaStopnja(3);
		stiri.interactable = LeveliManeger._instance.odklenjenaStopnja(4);
		pet.interactable = LeveliManeger._instance.odklenjenaStopnja(5);
		sest.interactable = LeveliManeger._instance.odklenjenaStopnja(6);
		sedem.interactable = LeveliManeger._instance.odklenjenaStopnja(7);
		osem.interactable = LeveliManeger._instance.odklenjenaStopnja(8);
		devet.interactable = LeveliManeger._instance.odklenjenaStopnja(9);
		deset.interactable = LeveliManeger._instance.odklenjenaStopnja(10);
		enajst.interactable = LeveliManeger._instance.odklenjenaStopnja(11);
		dvanajst.interactable = LeveliManeger._instance.odklenjenaStopnja(12);

		if (dve.interactable) {
			potkaNavodila.SetActive(false);
		}

		float[] casi = LeveliManeger._instance.getCase ();
		//cas1.text = (casi[0] > 0) ? "BEST: "+casovniFormat(casi[0])+"s":"BEST: N/A";
		Debug.Log (LeveliManeger._instance.getCas(2));
	    if (casi [0] >= 0) {
			level1.SetActive (true);
			level1.transform.FindChild("cas 1").GetComponent<Text>().text=casovniFormat(casi[0]);
		}
		if (casi [1] >= 0) {
			level2.SetActive (true);
			level2.transform.FindChild("cas 1").GetComponent<Text>().text=casovniFormat(casi[1]);
		}
		if (casi [2] >= 0) {
			level3.SetActive (true);
			level3.transform.FindChild("cas 1").GetComponent<Text>().text=casovniFormat(casi[2]);
		}
		if (casi [3] >= 0) {
			level4.SetActive (true);
			level4.transform.FindChild("cas 1").GetComponent<Text>().text=casovniFormat(casi[3]);
		}
		if (casi [4] >= 0) {
			level5.SetActive (true);
			level5.transform.FindChild("cas 1").GetComponent<Text>().text=casovniFormat(casi[4]);
		}
		if (casi [5] >= 0) {
			level6.SetActive (true);
			level6.transform.FindChild("cas 1").GetComponent<Text>().text=casovniFormat(casi[5]);
		}
		if (casi [6] >= 0) {
			level7.SetActive (true);
			level7.transform.FindChild("cas 1").GetComponent<Text>().text=casovniFormat(casi[6]);
		}
		if (casi [7] >= 0) {
			level8.SetActive (true);
			level8.transform.FindChild("cas 1").GetComponent<Text>().text=casovniFormat(casi[7]);
		}
		if (casi [8] >= 0) {
			level9.SetActive (true);
			level9.transform.FindChild("cas 1").GetComponent<Text>().text=casovniFormat(casi[8]);
		}
		if (casi [9] >= 0) {
			level10.SetActive (true);
			level10.transform.FindChild("cas 1").GetComponent<Text>().text=casovniFormat(casi[9]);
		}
		if (casi [10] >= 0) {
			level11.SetActive (true);
			level11.transform.FindChild("cas 1").GetComponent<Text>().text=casovniFormat(casi[10]);
		}
		if (casi [11] >= 0) {
			level12.SetActive (true);
			level12.transform.FindChild("cas 1").GetComponent<Text>().text=casovniFormat(casi[11]);
		}

		for (int i=0; i < casi.Length; i++) {
			if(casi[i]> 0){
				Debug.Log(casi[i]+"casi"+i+" "+casovniFormat(casi[i]));
				skupaj+=casi[i];
			}

		}
		LeveliManeger._instance.setSkupniCas (skupaj);
		if (skupaj > 0) {
			totalCas.text = casovniFormat (skupaj);
		} else {
			totalCas.text ="0";
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static string casovniFormatIgra(float cas){
		
		string minutes = Mathf.Floor(cas*10).ToString("00");
		//string seconds = Mathf.Floor(cas % 60).ToString("00");
		//string mil = Mathf.Floor((cas*10) % 10).ToString("0");
		
		return minutes;
	}

	public static string casovniFormat(float cas){

		string minutes = Mathf.Floor(cas*10).ToString("00");
		//string seconds = Mathf.Floor(cas % 60).ToString("00");
		//string mil = Mathf.Floor((cas*10) % 10).ToString("0");

		return minutes;
	}

	public void pritisnilPlay(int i){
		LeveliManeger._instance.ponastaviLevel (i);
		Application.LoadLevel ("level"+i);
		gameLogo.GetComponent<LoadingScreen> ().show ();
	}


	
}
