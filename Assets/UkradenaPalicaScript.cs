﻿using UnityEngine;
using System.Collections;

public class UkradenaPalicaScript : MonoBehaviour {

	// Use this for initialization
	public GameObject palcek;

	PalcekAI palcekSkripta;
	void Start () {
		palcekSkripta= palcek.GetComponent<PalcekAI> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.Equals (palcek)) {
			palcekSkripta.palica=2;
			palcek.transform.FindChild("palcekAnimacija").gameObject.GetComponent<Animator> ().SetFloat("odpiranje", 2);
			Destroy(gameObject);
		}
	}
}
