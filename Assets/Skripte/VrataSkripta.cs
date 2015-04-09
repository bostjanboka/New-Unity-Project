using UnityEngine;
using System.Collections;

public class VrataSkripta : MonoBehaviour {

	// Use this for initialization
	public bool premakni;
	public float speed;

	public bool zapri;

	public bool odprta;
	public bool zaprta;
	float zacetnaY;

	void Start () {
		zacetnaY = transform.localPosition.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (premakni) {
			zaprta = false;
			Vector3 move = new Vector3 (0, speed, 0) * Time.deltaTime;
			transform.Translate (move);
			Debug.Log(transform.localPosition.y);
			if (transform.localPosition.y >= -5) {
				premakni = false;
				Vector3 pos = transform.localPosition;
				pos.y = -5;
				transform.localPosition = pos;
				odprta = true;
			}
		} else if (zapri) {
			odprta = false;
			Vector3 move = new Vector3 (0, speed*-1, 0) * Time.deltaTime;
			transform.Translate (move);
			if (transform.localPosition.y <= zacetnaY) {
				zapri = false;
				Vector3 pos = transform.localPosition;
				pos.y = zacetnaY;
				transform.localPosition = pos;
				zaprta = true;
			}
		}
	}
}
