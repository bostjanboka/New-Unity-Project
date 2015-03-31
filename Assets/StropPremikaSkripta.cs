using UnityEngine;
using System.Collections;

public class StropPremikaSkripta : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public int smer;
	public float visinaY;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localPosition.y > 0) {
			smer = -1;
			Vector3 pos = transform.localPosition;
			pos.y = 0;
			transform.localPosition = pos;
		} 
		if (transform.localPosition.y < visinaY) {
			smer= 1;
			Vector3 pos = transform.localPosition;
			pos.y = visinaY;
			transform.localPosition = pos;
		}
		transform.Translate (new Vector3 (0, speed * smer * Time.deltaTime, 0));
	}
}
