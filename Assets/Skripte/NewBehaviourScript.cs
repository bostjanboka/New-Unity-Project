﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;

public class NewBehaviourScript : MonoBehaviour {

	//animacija
	int level;
	float timeToBeat;
	public float score;
	public int hp;
	public int trenutniLevel;
	public Text casi;


	public Animator anim;
	public Animation jawCane;

	// Use this for initialization
	GameObject junak;

	public GameObject powerUpSpirala;
	public GameObject spirala;
	public GameObject srca;
	public GameObject zgubil;

	public GameObject inputNavigacija;

	public bool omogociPremikanje = true;
	public bool stojimNaMestuX;
	public bool meritev;
	public bool strelOmogocen=true;


	public float speed;
	public float xTocka;
	float count;
	Vector3 pozicija;
	Rigidbody2D rigid;

	bool pressedD = false;
	bool pressedL = false;
	bool pressedS = false;
	bool bilZadet;

	public bool ustreli = false;
	InputNavigacija navSkripta;
	//GUIContent btn;
	int presses = 0;

	public int naloziReklamo=30;


	public int steviloSpiral;


	void Start () {


		if (Random.value * 100 < naloziReklamo) {
			Move.loadCelozaslonsko ();
			//oglasi.GetComponent<OglasiSkripta>().loadReklamo();
		}

		level = inputNavigacija.GetComponent<InputNavigacija> ().level;
		InfoLeveli temp = LeveliManeger._instance.getLevel ();
		hp = 4;

		bilZadet = false;

		trenutniLevel = temp.trenutniLevel;
		score = 999.99f;

		inputNavigacija.GetComponent<InputNavigacija> ().trenutniLevel = trenutniLevel;
		stojimNaMestuX = false;
		navSkripta = zgubil.GetComponent<InputNavigacija> ();
		pozicija = transform.position;
		rigid = GetComponent<Rigidbody2D> ();
		Transform animacija = transform.Find ("animacija");
		anim = animacija.gameObject.GetComponent<Animator> ();


		count = 1;
		steviloSpiral = 0;
		casi.text= PotkaSkripta.casovniFormat(score);

		timeToBeat = LeveliManeger._instance.getCas (level);
		if(timeToBeat > 0){
			if(score < timeToBeat){
				casi.color = new Color(1,24f/255,24f/255,150f/255);
			}else{
				casi.color = new Color(51f/255,192f/255,0,150f/255);
			}
		}


	}
	
	// Update is called once per frame
	void Update () {
		
		if (omogociPremikanje) {

			anim.SetFloat ("hitrost", 0);
			foreach (Touch touch in Input.touches) {

				Vector2 mousePosition = Camera.main.ScreenToWorldPoint (touch.position);
				Collider2D hitCollider = Physics2D.OverlapPoint (mousePosition);
				Debug.Log ("mouse pos " + mousePosition.x + " y " + mousePosition.y + " ");
				if (hitCollider.transform.name.Equals ("gumb_levo")) {
					Vector2 move = new Vector2 (-1 * speed, 0);
					anim.SetFloat ("hitrost", -1);
					move *= Time.deltaTime;
					transform.Translate (move);
				}
				if  (hitCollider.transform.name.Equals ("gumb_desno")) {
					Vector2 move = new Vector2 (speed, 0);
					anim.SetFloat ("hitrost", 1);
					move *= Time.deltaTime;
					transform.Translate (move);
				}
				if (hitCollider.transform.name.Equals ("gumb_strel") || ustreli) {
					Debug.Log ("zadetek strel");
					if (steviloSpiral == 0 && strelOmogocen) {
						if (powerUpSpirala) {
							Instantiate (powerUpSpirala, new Vector3 (transform.position.x, -9.62f, 2), Quaternion.identity);
						} else {
							Instantiate (spirala, new Vector3 (transform.position.x, -9.7f, 2), Quaternion.identity);
						}
						steviloSpiral++;

					}
					ustreli=false;
				}
			}
			if ( ustreli) {
				Debug.Log ("zadetek strel");
				if (steviloSpiral == 0) {
					if (powerUpSpirala) {
						Instantiate (powerUpSpirala, new Vector3 (transform.position.x, -9.62f, 2), Quaternion.identity);
					} else {
						Instantiate (spirala, new Vector3 (transform.position.x, -9.7f, 2), Quaternion.identity);
					}
					steviloSpiral++;
					
				}
				ustreli=false;
			}
		} else {
			if (transform.localPosition.x < xTocka) {
				stojimNaMestuX=false;
				transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
				anim.SetFloat ("hitrost", 1);
				Debug.Log("animacija hitrost 1");
			} else {
				stojimNaMestuX = true;
				anim.SetFloat ("hitrost", 0);
			}
			if ( ustreli) {
				Debug.Log ("zadetek strel");
				if (steviloSpiral == 0) {
					if (powerUpSpirala) {
						Instantiate (powerUpSpirala, new Vector3 (transform.position.x, -9.62f, 2), Quaternion.identity);
					} else {
						Instantiate (spirala, new Vector3 (transform.position.x, -9.7f, 2), Quaternion.identity);
					}
					steviloSpiral++;
					
				}
				ustreli=false;
			}
		}
		if (meritev) {
			score-=Time.deltaTime;
			if(score < 0){
				score=0;
			}

			casi.text= PotkaSkripta.casovniFormatIgra(score);
			casi.color=new Color(1, 1, 1);
			if(timeToBeat > 0){
				if(score < timeToBeat){
					//casi.color = new Color(1,24f/255,24f/255,150f/255);
				}else{
					casi.color = new Color(51f/255,192f/255,0,150f/255);
				}
			}

		}
		OnPressedSkripta.omogociStrel = strelOmogocen;
		inputNavigacija.GetComponent<InputNavigacija> ().setHUD (omogociPremikanje);
	}

	public void zacniCas(){
		meritev = true;
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag.Equals ("zogice")) {
			zgubilLevel();
		}
		else if (other.gameObject.tag.Equals ("zeleji")) {
			zgubilLevel();
		}
		else if (other.gameObject.tag.Equals ("jaw")) {
			zgubilLevel();
		}
	}

	public void zgubilLevel(){
		if (!bilZadet) {
			bilZadet=true;
			Move.showCelozaslonsko ();


			LeveliManeger._instance.saveProgres (--hp, trenutniLevel, score);
			InfoLeveli temp = LeveliManeger._instance.getLevel ();

			HighScoreManager._instance.SaveHighScore ("boka", 35);
			Time.timeScale = 0;
			inputNavigacija.GetComponent<InputNavigacija> ().trenutniLevel = temp.trenutniLevel;
			if (hp == 0) {
				zgubil.transform.Find ("life lost").gameObject.GetComponent<Text> ().text = "NO MORE LIVES";
				zgubil.transform.Find ("noHP").gameObject.SetActive (true);
				zgubil.transform.Find ("new game").gameObject.SetActive (false);
			}
		}

		zgubil.SetActive (true);
	}

	public void zmagalLevel(){
		LeveliManeger._instance.saveProgres ( hp, ++trenutniLevel, score);

		inputNavigacija.GetComponent<InputNavigacija> ().Zmagal ();
	}



}
