﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.game;

public class scrollView : MonoBehaviour {

	Vector2 scrollPos;
	public GUIStyle myStyle;
	public GUIStyle myStyleScore;

	public GUIStyle soda;
	public GUIStyle liha;

	string[] highscore;
	Camera camera2;
	Canvas score;
	void Awake(){
		camera2 = GameObject.Find("Main Camera").GetComponent<Camera> ();
		score = GameObject.Find("Score").GetComponent<Canvas>();
	}
	void OnGUI() // simply an example of a long ScrollView
	{
		if (score.enabled) {
			highscore = userService.scori;
			//highscore = HighScoreManager._instance.GetHighScore (); 
			scrollPos = GUI.BeginScrollView (
			new Rect (Screen.width * 0.3f, Screen.height * 0.17f, Screen.width * 0.4f, Screen.height * 0.59f), scrollPos,
			new Rect (Screen.width * 0.3f, Screen.height * 0.10f, Screen.width * 0.4f, 5300),
			myStyle, myStyle);
			// HOORAY THOSE TWO ARGUMENTS ELIMINATE
			// THE STUPID RIDICULOUS UNITY SCROLL BARS
			if(highscore != null){
				for (int i = 0; i < 100; i++) {
					for (int j=i; j <= highscore.Length; j++) {
						if (highscore.Length == j) {
							i = j;
							break;
						}
						if(j % 2 == 0){
							GUI.Box (new Rect (Screen.width * 0.3f, Screen.height * 0.1f + j * 53, Screen.width * 0.4f, 50), "", soda);
						}else{
							GUI.Box (new Rect (Screen.width * 0.3f, Screen.height * 0.1f + j * 53, Screen.width * 0.4f, 50), "", liha);
						}
						GUI.Box (new Rect (Screen.width * 0.3f, Screen.height * 0.1f + j * 53, Screen.width * 0.4f, 50), (j+1) + ". "+highscore[j].Split(':')[0], myStyle);
						GUI.Box (new Rect (Screen.width * 0.6f, Screen.height * 0.1f + j * 53, Screen.width * 0.1f, 50), ""+highscore[j].Split(':')[1], myStyleScore);
					}
					GUI.Box (new Rect (Screen.width * 0.3f, Screen.height * 0.1f + i * 53, Screen.width * 0.4f, 50), "", myStyle);

				}
			}
			GUI.EndScrollView ();
		}
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