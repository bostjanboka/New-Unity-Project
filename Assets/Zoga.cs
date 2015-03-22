using UnityEngine;
using System.Collections;

public class Zoga : MonoBehaviour {

	// Use this for initialization
	public int visina;
	public int speed;

	int povecanje;
	public float limit;

	void Start () {
		povecanje = 0;

	}
	
	// Update is called once per frame hhhhh
	void Update () {
		float vrednost = ((povecanje++) % limit) / limit * Mathf.PI * 2;
		float Y = visina * Mathf.Abs( Mathf.Sin(vrednost))*Time.deltaTime;
		transform.Translate(speed*Time.deltaTime,0,0);
		Vector3 pozicija = transform.position;
		pozicija.y = Y;
		transform.position = pozicija;
	}
}
