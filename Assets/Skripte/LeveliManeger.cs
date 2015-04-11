using UnityEngine;
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

	public void saveProgres(int level, int hp, int trenutniLevel, int score){
		if (!PlayerPrefs.HasKey ("Level" + level + "hp") || hp < 1) {
			PlayerPrefs.SetInt ("Level" + level + "score", 0);
			PlayerPrefs.SetInt ("Level" + level + "hp", 4);
			PlayerPrefs.SetInt ("Level" + level + "trenutniLevel", 0);
		}
		if (PlayerPrefs.HasKey ("Level" + level + "hp")) {
			if(hp > 0){
				int tempScore = PlayerPrefs.GetInt("Level" + level + "score");
				PlayerPrefs.SetInt ("Level" + level + "score", tempScore+score);
				PlayerPrefs.SetInt ("Level" + level + "hp", hp);
				PlayerPrefs.SetInt ("Level" + level + "trenutniLevel", trenutniLevel);
			}
		}
	}

	public InfoLeveli getLevel(int level){
		int i = level;
		if (!PlayerPrefs.HasKey ("Level" + level + "hp")) {
			PlayerPrefs.SetInt ("Level" + level + "score", 0);
			PlayerPrefs.SetInt ("Level" + level + "hp", 4);
			PlayerPrefs.SetInt ("Level" + level + "trenutniLevel", 0);
		}
		InfoLeveli temp = new InfoLeveli ();
		
		temp.hp = PlayerPrefs.GetInt("Level" + i + "hp");
		temp.trenutniLevel = PlayerPrefs.GetInt("Level" + i + "trenutniLevel");
		temp.score = PlayerPrefs.GetInt ("Level" + i + "score");

		return temp;
	}

	public List<InfoLeveli> GetLeveleInfo ()
	{
		List<InfoLeveli> infoLeveli = new List<InfoLeveli> ();
		int i = 1;
		while (i<=leveliLength && PlayerPrefs.HasKey("Level"+i+"hp")) {
			InfoLeveli temp = new InfoLeveli ();

			temp.hp = PlayerPrefs.GetInt("Level" + i + "hp");
			temp.trenutniLevel = PlayerPrefs.GetInt("Level" + i + "trenutniLevel");
			temp.score = PlayerPrefs.GetInt ("Level" + i + "score");

			infoLeveli.Add (temp);
			i++;
		}
		return infoLeveli;
	}
}
