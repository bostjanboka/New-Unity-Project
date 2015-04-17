using UnityEngine;
using System.Collections;
public class LoadingScreen : MonoBehaviour
{
	public float delayTime=3;


	public GameObject slikaOzadja;
	public GameObject animacija;

	bool showed = false;


	void Start ()
	{

	}

	void Awake()
	{

		slikaOzadja.GetComponent<SpriteRenderer> ().enabled = false;
		animacija.GetComponent<Animator> ().enabled = false;
		animacija.GetComponent<SpriteRenderer> ().enabled = false;

		DontDestroyOnLoad(gameObject);
	}
	public void show()
	{
		showed = true;
		Debug.Log("show show");
		slikaOzadja.GetComponent<SpriteRenderer> ().enabled = true;
		animacija.GetComponent<Animator> ().enabled = true;
		animacija.GetComponent<SpriteRenderer> ().enabled = true;
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
		//Debug.Log("IZGINI");
		//gameObject.GetComponent<Animator> ().enabled = false;
		slikaOzadja.GetComponent<SpriteRenderer> ().enabled = false;
		animacija.GetComponent<Animator> ().enabled = false;
		animacija.GetComponent<SpriteRenderer> ().enabled = false;
		Destroy (gameObject);
	}
	
	void Update()
	{
		if (showed && Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel("ZemljevidScena");
			Destroy (gameObject);
		}
		/*if (timer >= 0) {
			timer += Time.deltaTime;
			Debug.Log("IZGINI pdate" + timer);
		}

		if (delayTime < timer) {
			Debug.Log("konec stetja" + timer);
		}*/

		if (showed&&Time.timeScale == 1 && !Application.isLoadingLevel) {
			//Debug.Log("IZGINI pdate");
			hide();
		}
	}

}
