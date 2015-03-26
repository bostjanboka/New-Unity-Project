using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class scrollView : MonoBehaviour {

	Vector2 scrollPos;
	public GUIStyle myStyle;

	List<Scores> highscore;
	void OnGUI() // simply an example of a long ScrollView
	{
		highscore = new List<Scores>();
		highscore = HighScoreManager._instance.GetHighScore(); 
		scrollPos = GUI.BeginScrollView(
			new Rect(Screen.width*0.3f,Screen.height*0.1f,Screen.width*0.4f,Screen.height*0.8f),scrollPos,
			new Rect(Screen.width*0.3f,Screen.height*0.1f,Screen.width*0.4f,530),
			myStyle,myStyle );
		// HOORAY THOSE TWO ARGUMENTS ELIMINATE
		// THE STUPID RIDICULOUS UNITY SCROLL BARS

		for (int i = 0; i < 10; i++) {
			for (int j=i; j <= highscore.Count; j++) {
				if(highscore.Count == j){
					i = j;
					break;
				}
				GUI.Box (new Rect (Screen.width * 0.3f, Screen.height * 0.1f + j * 53, Screen.width * 0.4f, 50), "" + highscore [j].score, myStyle);
			}
			GUI.Box (new Rect (Screen.width * 0.3f, Screen.height * 0.1f + i * 53, Screen.width * 0.4f, 50), "-empty-", myStyle);

		}
		GUI.EndScrollView ();
	}
	void Update() // so, make it scroll with the user's finger
	{
		if(Input.touchCount == 0) return;
		Touch touch = Input.touches[0];
		if (touch.phase == TouchPhase.Moved)
		{
			// simplistically, scrollPos.y += touch.deltaPosition.y;
			// but that doesn't actually work
			// don't forget you need the actual delta "on the glass"
			// fortunately it's easy to do this...
			float dt = Time.deltaTime / touch.deltaTime;
			if (dt == 0 || float.IsNaN(dt) || float.IsInfinity(dt))
				dt = 1.0f;
			Vector2 glassDelta = touch.deltaPosition * dt;
			scrollPos.y += glassDelta.y;
		}
	}
}
