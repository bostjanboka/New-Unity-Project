using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeveliManeger : MonoBehaviour {

	// Use this for initialization
	private static LeveliManeger m_instance;
	private const int leveliLength = 12;
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
		PlayerPrefs.SetInt ("StopnjaOdkleni" + stopnja, 1);
		PlayerPrefs.Save ();
	}

	public bool odklenjenaStopnja(int stopnja){
		if (!PlayerPrefs.HasKey ("StopnjaOdkleni" + stopnja)) {
			PlayerPrefs.SetInt ("StopnjaOdkleni" + stopnja, 0);
			Debug.Log("odklenjena stopnja nima kljuca "+stopnja);
		}
		int x = PlayerPrefs.GetInt ("StopnjaOdkleni"+stopnja);
		Debug.Log("odklenjena stopnjakljuca "+stopnja +" vrednost x"+x);
		PlayerPrefs.Save ();
		if (x == 0) {
			return false;
		} else {
			return true;
		}
	}


	public void disableRate(){
		PlayerPrefs.SetInt ("pokaziRate",0);
	}
	public int pokaziRate(){
		if (!PlayerPrefs.HasKey ("pokaziRate")) {
			PlayerPrefs.SetInt("pokaziRate",1);
			PlayerPrefs.Save();
		}
		return PlayerPrefs.GetInt ("pokaziRate");
	}	

	public void povecajObisk(){
		PlayerPrefs.SetInt ("ObiskalIgro", obiskalIgro()+1);
		PlayerPrefs.Save();
	}

	public int obiskalIgro(){
		if (!PlayerPrefs.HasKey ("ObiskalIgro")) {
			PlayerPrefs.SetInt ("ObiskalIgro", 0);
			PlayerPrefs.Save();
			return 0;
		}
			int x = PlayerPrefs.GetInt ("ObiskalIgro");
			return x;
	}

	public void saveProgres(int hp, int trenutniLevel, float score){
		if (hp < 1) {
			PlayerPrefs.SetFloat ("Leveli"  + "score", 0);
			PlayerPrefs.SetInt ("Leveli"  + "hp", 4);
			PlayerPrefs.SetInt ("Leveli" + "trenutniLevel", 0);
		} 

		if(hp > 0){
			float tempScore = PlayerPrefs.GetFloat("Leveli"  + "score");
			PlayerPrefs.SetFloat ("Leveli" + "score", score);
			PlayerPrefs.SetInt ("Leveli"  + "hp", hp);
			PlayerPrefs.SetInt ("Leveli"  + "trenutniLevel", trenutniLevel);
		}
		PlayerPrefs.Save ();

	}

	public float naredilStopnjo(){
		nastaviCas(PlayerPrefs.GetInt ("Levelilevel"),PlayerPrefs.GetFloat ("Leveli"  + "score"));
		PlayerPrefs.SetInt("Levelilevel",-1);
		PlayerPrefs.Save ();
		return PlayerPrefs.GetFloat ("Leveli"  + "score");
	}

	public void ponastaviLevel(int stopnja){

		PlayerPrefs.SetInt("Levelilevel",stopnja);
		PlayerPrefs.SetFloat ("Leveli"  + "score", 0);
		PlayerPrefs.SetInt ("Leveli" + "hp", 4);
		PlayerPrefs.SetInt ("Leveli"  + "trenutniLevel", 0);
		PlayerPrefs.Save ();
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
		Debug.Log("Prvic1"+cas);
		if (!PlayerPrefs.HasKey ("Stopnja" + stopnja) || PlayerPrefs.GetFloat ("Stopnja" + stopnja) < 1) {
			PlayerPrefs.SetFloat ("Stopnja" + stopnja, cas);
			Debug.Log("Prvic"+cas);
		} else {
			if(PlayerPrefs.GetFloat ("Stopnja" + stopnja) > cas ){
				PlayerPrefs.SetFloat ("Stopnja" + stopnja, cas);
				Debug.Log("Drugic"+cas);
			}

		}
		PlayerPrefs.Save ();
	}

	public float getCas(int i){
		if (!PlayerPrefs.HasKey ("Stopnja" + i)) {
			return -1;
		} else {
			return PlayerPrefs.GetFloat ("Stopnja" + i);
		}
	}

	public float[] getCase(){
		float[] casi = new float[leveliLength];
		for (int i=0; i < casi.Length; i++) {
			if (!PlayerPrefs.HasKey ("Stopnja" + (i+1))) {
				casi [i] = -1;
			}else{
				casi[i] = PlayerPrefs.GetFloat("Stopnja"+(i+1));
			}
		}
		 
		return casi;
	}

	public string getIdScore(){
		if (PlayerPrefs.HasKey ("IdScore")) {
			return PlayerPrefs.GetString ("IdScore");
		} else {
			return null;
		}
	}

	public void setIdScore(string idScore){
		PlayerPrefs.SetString ("IdScore",idScore);
	}


}
