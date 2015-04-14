﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeveliManeger : MonoBehaviour {

	// Use this for initialization
	private static LeveliManeger m_instance;
	private const int leveliLength = 6;
	public static LeveliManeger _instance {
		get {
			if (m_instance == null) {
				m_instance = new GameObject ("LeveliManeger").AddComponent<LeveliManeger> ();
			}
			return m_instance;
		}
	}
	void Awake ()
	{
		if (m_instance == null) {
			m_instance = this;
		} else if (m_instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}

	public void odkleniStopnjo(int stopnja){
		PlayerPrefs.SetInt ("Stopnja" + stopnja, 1);
	}

	public bool odklenjenaStopnja(int stopnja){
		if (!PlayerPrefs.HasKey ("Stopnja" + stopnja)) {
			PlayerPrefs.SetInt ("Stopnja" + stopnja, 0);
		}
		int x = PlayerPrefs.GetInt ("Stopnja"+stopnja);
		if (x == 0) {
			return false;
		} else {
			return true;
		}
	}

	public void saveProgres(int hp, int trenutniLevel, float score){
		if (hp < 1) {
			PlayerPrefs.SetFloat ("Leveli"  + "score", 0);
			PlayerPrefs.SetInt ("Leveli"  + "hp", 4);
			PlayerPrefs.SetInt ("Leveli" + "trenutniLevel", 0);
		} 

		if(hp > 0){
			float tempScore = PlayerPrefs.GetFloat("Leveli"  + "score");
			PlayerPrefs.SetFloat ("Leveli" + "score", tempScore+score);
			PlayerPrefs.SetInt ("Leveli"  + "hp", hp);
			PlayerPrefs.SetInt ("Leveli"  + "trenutniLevel", trenutniLevel);
		}

	}

	public float naredilStopnjo(){
		LeveliManeger._instance.nastaviCas(PlayerPrefs.GetInt ("Levelilevel"),PlayerPrefs.GetFloat ("Leveli"  + "score"));
		PlayerPrefs.SetInt("Levelilevel",-1);
		return PlayerPrefs.GetFloat ("Leveli"  + "score");
	}

	public void ponastaviLevel(int stopnja){

		PlayerPrefs.SetInt("Levelilevel",stopnja);
		PlayerPrefs.SetFloat ("Leveli"  + "score", 0);
		PlayerPrefs.SetInt ("Leveli" + "hp", 4);
		PlayerPrefs.SetInt ("Leveli"  + "trenutniLevel", 0);
		
	}

	public InfoLeveli getLevel(){

		if (!PlayerPrefs.HasKey ("Leveli" + "hp")) {
			PlayerPrefs.SetInt("Leveli"+"level",-1);
			PlayerPrefs.SetFloat ("Leveli"  + "score", 0);
			PlayerPrefs.SetInt ("Leveli"  + "hp", 4);
			PlayerPrefs.SetInt ("Leveli" + "trenutniLevel", 0);
		}
		InfoLeveli temp = new InfoLeveli ();
		temp.level = PlayerPrefs.GetInt ("Leveli"+"level");
		temp.hp = PlayerPrefs.GetInt("Leveli"  + "hp");
		temp.trenutniLevel = PlayerPrefs.GetInt("Leveli" + "trenutniLevel");
		temp.score = PlayerPrefs.GetFloat ("Leveli" + "score");

		return temp;
	}

	public void nastaviCas(int stopnja,float cas){
		if (!PlayerPrefs.HasKey ("Stopnja" + stopnja)) {
			PlayerPrefs.SetFloat ("Stopnja" + stopnja, cas);
		} else {
			if(PlayerPrefs.GetFloat ("Stopnja" + stopnja) > cas ){
				PlayerPrefs.SetFloat ("Stopnja" + stopnja, cas);
			}

		}
	}

	public float[] getCase(){
		float[] casi = new float[leveliLength];
		if (!PlayerPrefs.HasKey ("Stopnja" + 1)) {
			casi [0] = -1;
		} else {
			casi[0] = PlayerPrefs.GetFloat ("Stopnja" + 1);
		}
		if (!PlayerPrefs.HasKey ("Stopnja" + 2)) {
			casi [1] = -1;
		} else {
			casi[1] = PlayerPrefs.GetFloat ("Stopnja" + 2);
		}
		if (!PlayerPrefs.HasKey ("Stopnja" + 3)) {
			casi [2] = -1;
		} else {
			casi[2] = PlayerPrefs.GetFloat ("Stopnja" + 3);
		}
		if (!PlayerPrefs.HasKey ("Stopnja" + 4)) {
			casi [3] = -1;
		} else {
			casi[3] = PlayerPrefs.GetFloat ("Stopnja" + 4);
		}
		if (!PlayerPrefs.HasKey ("Stopnja" + 5)) {
			casi [4] = -1;
		} else {
			casi[4] = PlayerPrefs.GetFloat ("Stopnja" + 5);
		}
		if (!PlayerPrefs.HasKey ("Stopnja" + 6)) {
			casi [5] = -1;
		} else {
			casi[5] = PlayerPrefs.GetFloat ("Stopnja" + 6);
		}
		return casi;
	}


}
