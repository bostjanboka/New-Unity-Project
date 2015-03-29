﻿using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	GameObject junak;

	public GameObject powerUpSpirala;
	public GameObject spirala;
	public GameObject srca;
	public GameObject zgubil;

	public int hp;

	public float speed;
	float count;
	Vector3 pozicija;
	Rigidbody2D rigid;

	bool pressedD = false;
	bool pressedL = false;
	bool pressedS = false;
	InputNavigacija navSkripta;
	//GUIContent btn;
	int presses = 0;

	public int steviloSpiral;


	void Start () {
		//junak = GameObject.("junak1");
		navSkripta = zgubil.GetComponent<InputNavigacija> ();
		speed = 2;
		count = 1;
		pozicija = transform.position;
		rigid = GetComponent<Rigidbody2D> ();
		steviloSpiral = 0;
		//btn = new GUIContent("Button");
		//electorSprite = Instantiate (tileSelectionMarker, Vector3(0,0, 0), Quaternion.identity);
		//Instantiate (spirala, new Vector3(3, -6, 0), Quaternion.identity);

		//Instantiate (srca, new Vector3(0.3f, (Screen.height)/50, 0), Quaternion.identity);
		Debug.Log ("res "+Screen.currentResolution.height);
		Debug.Log ("hei "+Screen.height);
		Debug.Log ("dpi "+Screen.dpi);

	}
	
	// Update is called once per frame
	void Update () {

		foreach (Touch touch in Input.touches) {

			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(touch.position);
			Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);
			Debug.Log("mouse pos "+mousePosition.x+" y "+mousePosition.y+" ");
			if(hitCollider.transform.name.Equals("gumb_levo")){
				Debug.Log("zadetek");
				Vector2 move = new Vector2(-1*speed,0);
				move *= Time.deltaTime;
				transform.Translate(move);
			}
			if(hitCollider.transform.name.Equals("gumb_desno")){
				Vector2 move = new Vector2(speed,0);
				move *= Time.deltaTime;
				transform.Translate(move);
			}
			if(hitCollider.transform.name.Equals("gumb_strel")){
				Debug.Log("zadetek strel");
				if(steviloSpiral == 0)
				{
					if(powerUpSpirala)
					{
						Instantiate (powerUpSpirala, new Vector3(transform.position.x, -6, 2), Quaternion.identity);
					}
					else{
						Instantiate (spirala, new Vector3(transform.position.x, -6, 2), Quaternion.identity);
					}
					steviloSpiral++;
				}
			}
		}

	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag.Equals ("zogice")) {
			HighScoreManager._instance.SaveHighScore("boka",35);
			Time.timeScale = 0;
			zgubil.SetActive (true);
		}
		if (other.gameObject.tag.Equals ("zeleji")) {
			HighScoreManager._instance.SaveHighScore("boka",35);
			Time.timeScale = 0;
			zgubil.SetActive (true);
		}
		if (other.gameObject.tag.Equals ("jaw")) {
			HighScoreManager._instance.SaveHighScore("boka",35);
			Time.timeScale = 0;
			zgubil.SetActive (true);
		}
	}



	void OnCollisionEnter2D (Collision2D col)
	{

		Debug.Log("blaaaaaa");
	}

	void OnCollisionStay (Collision col)
	{

		Debug.Log("blaaaaaa2");
	}

	void OnCollisionExit (Collision col)
	{

		Debug.Log("blaaaaaa3");
	}
}
