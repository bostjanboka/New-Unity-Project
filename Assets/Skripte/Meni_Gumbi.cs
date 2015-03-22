using UnityEngine;
using System.Collections;


public class Meni_Gumbi : MonoBehaviour {

	// Use this for initialization
	bool pressedPlay;
	void Start () {
		pressedPlay = false;
	}
	
	// Update is called once per frame
	void Update () {

		foreach (Touch touch in Input.touches) {


		}
		if (Input.GetMouseButtonUp (0)) {
			pressedPlay = false;
			
		}
		
		if(Input.GetMouseButtonDown(0)){
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);
			Debug.Log("mouse pos "+mousePosition.x+" y "+mousePosition.y+" ");
			if(hitCollider.transform.name.Equals("gumb_play")){
				Debug.Log("zadetek");
				pressedPlay = true;
			}

		}
		
		if (pressedPlay) {
			Application.LoadLevel ("level10"); 
			Debug.Log("zadetek");
		}

	}
}
