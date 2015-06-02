using UnityEngine;
using System.Collections;
public class LoadingScreen : MonoBehaviour
{
	public float delayTime=3;
   


	public GameObject slikaOzadja;
	public GameObject animacija;
	public GameObject logo;


	bool showed = false;




	void Start ()
	{
		Vector3 poz = GameObject.Find("Main Camera").transform.position;
		poz.z = gameObject.transform.position.z;
		gameObject.transform.position = poz;

	}

	void Awake()
	{

		slikaOzadja.GetComponent<SpriteRenderer> ().enabled = false;
		if (logo) {
			logo.GetComponent<SpriteRenderer> ().enabled = false;
		}
		if (animacija) {
			//animacija.GetComponent<Animator> ().enabled = false;
			//animacija.GetComponent<SpriteRenderer> ().enabled = false;
			animacija.SetActive(false);
		}


		DontDestroyOnLoad(gameObject);
	}
	public void show()
	{

		showed = true;
		Debug.Log("show show");
		if (logo) {
			logo.GetComponent<SpriteRenderer> ().enabled = true;
		}
		slikaOzadja.GetComponent<SpriteRenderer> ().enabled = true;
		if (animacija) {
			//animacija.GetComponent<Animator> ().enabled = true;
			//animacija.GetComponent<SpriteRenderer> ().enabled = true;
			animacija.SetActive(true);
		}
		Time.timeScale = .0000001f;
		StartCoroutine(Wait(Time.timeScale * delayTime));
	}

	IEnumerator Wait(float duration)
	{
		//This is a coroutine
		Debug.Log("Start Wait() function. The time is: "+Time.time);
		Debug.Log( "Float duration = "+duration);
		yield return new WaitForSeconds(duration);   //Wait
		Debug.Log("End Wait() function and the time is: "+Time.time);
		Time.timeScale = 1;

	}

	public void hide()
	{
		showed = false;
		//Debug.Log("IZGINI");
		//gameObject.GetComponent<Animator> ().enabled = false;
		slikaOzadja.GetComponent<SpriteRenderer> ().enabled = false;
		if (logo) {
			logo.GetComponent<SpriteRenderer> ().enabled = false;
		}
		if (animacija) {
			//animacija.GetComponent<Animator> ().enabled = false;
			//animacija.GetComponent<SpriteRenderer> ().enabled = false;
			animacija.SetActive(false);
		}
		//Destroy (gameObject);
	}
	
	void Update()
	{
		if (showed && Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel("MeniScena");
			Destroy (gameObject);
		}
		/*if (timer >= 0) {
			timer += Time.deltaTime;
			Debug.Log("IZGINI pdate" + timer);
		}

		if (delayTime < timer) {
			Debug.Log("konec stetja" + timer);
		}*/

		else if (showed && Time.timeScale == 1 && !Application.isLoadingLevel) {
			//Debug.Log("IZGINI pdate");
			hide();
		}


	}

}
