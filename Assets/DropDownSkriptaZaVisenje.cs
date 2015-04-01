using UnityEngine;
using System.Collections;

public class DropDownSkriptaZaVisenje : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public float visina;
	public bool sprozi;
	void Start () {
		sprozi = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (sprozi && transform.position.y > visina) {
			transform.Translate (new Vector3(0,-speed*Time.deltaTime,0));
			//sprozi=false;
		}
	}
}
