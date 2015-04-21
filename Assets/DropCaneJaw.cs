using UnityEngine;
using System.Collections;

public class DropCaneJaw : MonoBehaviour {

	// Use this for initialization
	public GameObject spiralaJaw;
	NewBehaviourScript junakSkripta;
	public RuntimeAnimatorController anim;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("noter sem spirala");
		if (other.gameObject.tag.Equals ("junak")) {

			other.gameObject.transform.Find("animacija").gameObject.GetComponent<Animator>().runtimeAnimatorController = anim;

			junakSkripta = other.gameObject.GetComponent<NewBehaviourScript>();
			junakSkripta.powerUpSpirala = spiralaJaw;
			junakSkripta.strelOmogocen=true;
			Destroy(gameObject);
			Debug.Log ("noter sem");
		}
	}
}
