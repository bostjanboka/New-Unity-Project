using UnityEngine;
using System.Collections;

public class OnPressedSkripta : MonoBehaviour {

	// Use this for initialization
	public static bool omogociStrel=true;

	public Sprite onPressed;
	public Sprite normal;
	public Sprite disable;

	Rigidbody2D rigid;
	SpriteRenderer render;
	bool pressed;
	public static bool omogocenoPremikanje=true;
	void Start () {
		render = GetComponent<SpriteRenderer> ();
		render.sprite = normal;
		pressed = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (disable && omogociStrel == false) {
			render.sprite = disable;
		} else {
			pressed = false;
			foreach (Touch touch in Input.touches) {
				Vector2 touchPosition = Camera.main.ScreenToWorldPoint (touch.position);
				Collider2D hitCollider = Physics2D.OverlapPoint (touchPosition);
				if (omogocenoPremikanje && hitCollider.transform.name.Equals (gameObject.name)) {
					pressed = true;
					render.sprite = onPressed;
				}
			}
			if (!pressed) {
				render.sprite = normal;
			
			}
		}
	}
}
