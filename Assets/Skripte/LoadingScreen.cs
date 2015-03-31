using UnityEngine;
using System.Collections;
public class LoadingScreen : MonoBehaviour
{

	void Awake()
	{
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		DontDestroyOnLoad(gameObject);
	}
	public void show()
	{
		gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		//Time.timeScale = .0000001f;
		//StartCoroutine(Wait(Time.timeScale * 5));
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
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
	}
	
	void Update()
	{
		if(!Application.isLoadingLevel)
			hide();

	}

}
