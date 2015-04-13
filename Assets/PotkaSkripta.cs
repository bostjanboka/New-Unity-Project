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
	void Start () {


		//ena.interactable = LeveliManeger._instance.odklenjenaStopnja(1);
		dve.interactable = LeveliManeger._instance.odklenjenaStopnja(2);;
		tri.interactable = LeveliManeger._instance.odklenjenaStopnja(3);;
		stiri.interactable = LeveliManeger._instance.odklenjenaStopnja(4);;
		pet.interactable = LeveliManeger._instance.odklenjenaStopnja(5);;
		sest.interactable = LeveliManeger._instance.odklenjenaStopnja(6);;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void pritisnilEna(){
		Application.LoadLevel ("level1");
	}

	public void pritisnilDva(){
		Application.LoadLevel ("level4");
	}

	public void pritisnilTri(){
		Application.LoadLevel ("level5");
	}

	public void pritisnilStiri(){
		Application.LoadLevel ("level8");
	}

	public void pritisnilPet(){
		Application.LoadLevel ("level9");
	}

	public void pritisnilSest(){
		Application.LoadLevel ("level12");
	}
}
