﻿using UnityEngine;
using System.Collections;

public class OnPressedSkripta : MonoBehaviour {

	// Use this for initialization
	public Sprite onPressed;
	public Sprite normal;

	Rigidbody2D rigid;
	SpriteRenderer render;
	bool pressed;
	void Start () {
		render = GetComponent<SpriteRenderer> ();
		render.sprite = normal;
		pressed = false;

	}
	
	// Update is called once per frame
	void Update () {
		pressed = false;
		foreach (Touch touch in Input.touches) {
			Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
			Collider2D hitCollider = Physics2D.OverlapPoint(touchPosition);
			if (hitCollider.transform.name.Equals (gameObject.name)) {
				pressed = true;
				render.sprite = onPressed;
			}
		}
		if(!pressed){
			render.sprite = normal;
			
		}
	}
}
