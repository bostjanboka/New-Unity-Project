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
		zacetnaY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (premakni) {
			zaprta = false;
			Vector3 move = new Vector3 (0, speed, 0) * Time.deltaTime;
			transform.Translate (move);
			if (transform.position.y >= 2.6f) {
				premakni = false;
				Vector3 pos = transform.position;
				pos.y = 2.6f;
				transform.position = pos;
				odprta = true;
			}
		} else if (zapri) {
			odprta = false;
			Vector3 move = new Vector3 (0, speed*-1, 0) * Time.deltaTime;
			transform.Translate (move);
			if (transform.position.y <= zacetnaY) {
				zapri = false;
				Vector3 pos = transform.position;
				pos.y = zacetnaY;
				transform.position = pos;
				zaprta = true;
			}
		}
	}
}
