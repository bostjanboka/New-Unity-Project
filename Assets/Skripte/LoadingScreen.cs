using UnityEngine;
using System.Collections;
public class LoadingScreen : MonoBehaviour
{
	public float delayTime=1;
	
	private float timer;

	bool showed = false;


	void Start ()
	{
		timer = -3;
	}

	void Awake()
	{
		gameObject.GetComponent<Animator> ().enabled = false;
		DontDestroyOnLoad(gameObject);
	}
	public void show()
	{
		showed = true;
		Debug.Log("show show");
		timer = 0;
		gameObject.GetComponent<Animator> ().enabled = true;
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
		Debug.Log("IZGINI");
		gameObject.GetComponent<Animator> ().enabled = false;
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
	}
	
	void Update()
	{
		/*if (timer >= 0) {
			timer += Time.deltaTime;
			Debug.Log("IZGINI pdate" + timer);
		}

		if (delayTime < timer) {
			Debug.Log("konec stetja" + timer);
		}*/

		if (showed&&Time.timeScale == 1 && !Application.isLoadingLevel) {
			Debug.Log("IZGINI pdate");
			hide();
		}
	}

}
