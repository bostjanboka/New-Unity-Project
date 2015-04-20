using UnityEngine;
using System.Collections;
//using UnityPluginForWindowsPhone;




//using PlugInWP;



public class Move : MonoBehaviour {

	// Use this for initialization
	public bool prikaziReklamoBool=false;
	public bool ugasniReklamoBool=false;

	public bool loadCelo=false;
	public bool showCelo=false;


	void Start () {
		//gameObject.AddComponent (PlugInWP.Class2);
		Debug.Log(""+UnityPluginForWindowsPhone.Class1.GetDeviceName);
		//UnityPluginForWindowsPhone.Class1.konstruktor ();


		//PlayerPrefs.DeleteAll ();
		//PlayerPrefs.Save ();


	}

	public static void ugasniReklamo(){
		UnityPluginForWindowsPhone.Class1.ugasniReklamo ();
	}

	public static void prizgiReklamo(){
		UnityPluginForWindowsPhone.Class1.prizgiReklamo ();
	}

	public static void loadCelozaslonsko(){
		UnityPluginForWindowsPhone.Class1.loadCelozaslonsko ();
	}

	public static void showCelozaslonsko(){
		UnityPluginForWindowsPhone.Class1.showCelozaslonsko ();
	}

	
	// Update is called once per frame
	void Update () {
		if (prikaziReklamoBool) {
			prikaziReklamoBool=false;
			prizgiReklamo();
		}

		if (ugasniReklamoBool) {
			ugasniReklamoBool=false;
			ugasniReklamo();
		}

		if (loadCelo) {
			loadCelo=false;
			loadCelozaslonsko();
		}

		if (showCelo) {
			showCelo=false;
			showCelozaslonsko();
		}

	
	}

	public void desno()
	{
		Debug.Log("desno");
	}

	public void levo()
	{
		Debug.Log ("levo");
	}
}
