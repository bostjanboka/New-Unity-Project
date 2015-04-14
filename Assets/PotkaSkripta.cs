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

	public Text cas1;
	public Text cas2;
	public Text cas3;
	public Text cas4;
	public Text cas5;
	public Text cas6;

	void Start () {


		//ena.interactable = LeveliManeger._instance.odklenjenaStopnja(1);
		dve.interactable = LeveliManeger._instance.odklenjenaStopnja(2);
		tri.interactable = LeveliManeger._instance.odklenjenaStopnja(3);
		stiri.interactable = LeveliManeger._instance.odklenjenaStopnja(4);
		pet.interactable = LeveliManeger._instance.odklenjenaStopnja(5);
		sest.interactable = LeveliManeger._instance.odklenjenaStopnja(6);

		float[] casi = LeveliManeger._instance.getCase ();
		cas1.text = (casi[0] > 0) ? casi[0]+"s":"N/A";
		cas2.text = (casi[1] > 0) ? casi[1]+"s":"N/A";
		cas3.text = (casi[2] > 0) ? casi[2]+"s":"N/A";
		cas4.text = (casi[3] > 0) ? casi[3]+"s":"N/A";
		cas5.text = (casi[4] > 0) ? casi[4]+"s":"N/A";
		cas6.text = (casi[5] > 0) ? casi[5]+"s":"N/A";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void pritisnilEna(){
		LeveliManeger._instance.ponastaviLevel (1);
		Application.LoadLevel ("level1");
	}

	public void pritisnilDva(){
		LeveliManeger._instance.ponastaviLevel (2);
		Application.LoadLevel ("level4");
	}

	public void pritisnilTri(){
		LeveliManeger._instance.ponastaviLevel (3);
		Application.LoadLevel ("level5");
	}

	public void pritisnilStiri(){
		LeveliManeger._instance.ponastaviLevel (4);
		Application.LoadLevel ("level8");
	}

	public void pritisnilPet(){
		LeveliManeger._instance.ponastaviLevel (5);
		Application.LoadLevel ("level9");
	}

	public void pritisnilSest(){
		LeveliManeger._instance.ponastaviLevel (6);
		Application.LoadLevel ("level12");
	}
}
