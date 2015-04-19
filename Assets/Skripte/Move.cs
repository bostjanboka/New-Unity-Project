using UnityEngine;
using System.Collections;
//using UnityPluginForWindowsPhone;




//using PlugInWP;



public class Move : MonoBehaviour {

	// Use this for initialization
	public bool prikaziReklamoBool=false;
	public bool ugasniReklamoBool=false;
	void Start () {
		//gameObject.AddComponent (PlugInWP.Class2);
		Debug.Log(""+UnityPluginForWindowsPhone.Class1.GetDeviceName);
		//UnityPluginForWindowsPhone.Class1.konstruktor ();
		UnityPluginForWindowsPhone.Class1.showCelozaslonsko ();
		UnityPluginForWindowsPhone.Class1.prizgiCelozaslonsko ();
		//PlayerPrefs.DeleteAll ();
		//PlayerPrefs.Save ();


	}

	public static void ugasniReklamo(){
		UnityPluginForWindowsPhone.Class1.ugasniReklamo ();
	}

	public static void prizgiReklamo(){
		UnityPluginForWindowsPhone.Class1.prizgiReklamo ();
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
