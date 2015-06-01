using UnityEngine;
using System.Collections;

public class CameraSize : MonoBehaviour {

	// Use this for initialization
	Camera cam;
	public float size=20;
	public GameObject tocka;

	void Start () {
		cam = gameObject.GetComponent<Camera> ();
		cam.orthographicSize = size * Screen.height / Screen.width * 0.5f;

		//gameObject.transform.position = cam.ScreenToWorldPoint (new Vector3(cam.WorldToScreenPoint(gameObject.transform.position).x,cam.WorldToScreenPoint(tocka.transform.position).y,0));

		Vector3 pos = cam.WorldToScreenPoint (tocka.gameObject.transform.position);
		pos.y = pos.y;
		gameObject.transform.position = cam.ScreenToWorldPoint (pos);
		pos = cam.WorldToScreenPoint (gameObject.transform.position);
		pos.y = pos.y * 2;
		pos.z = -10;
		gameObject.transform.position = cam.ScreenToWorldPoint (pos);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
