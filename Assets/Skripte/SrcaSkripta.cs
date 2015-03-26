using UnityEngine;
using System.Collections;

public class SrcaSkripta : MonoBehaviour {

	// Use this for initialization
	public Sprite rdeca;
	public Sprite bela;
	public int rang;

	GameObject heroj;
	NewBehaviourScript skripta;

	SpriteRenderer render;


	void Start () {
		render = GetComponent<SpriteRenderer> ();
		heroj = GameObject.Find ("junak1");
		skripta = heroj.GetComponent<NewBehaviourScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (skripta.hp >= rang) {
			render.sprite = rdeca;
		} else {
			render.sprite = bela;
		}
	}

	public void zamenjaj(int x){
		if (x == 0) {
			render.sprite = bela;
		} else if(x == 1){
			render.sprite = rdeca;
		}

	}
}
