using UnityEngine;
using System.Collections;
//using UnityPluginForWindowsPhone;




//using PlugInWP;



public class Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//gameObject.AddComponent (PlugInWP.Class2);
		Debug.Log(""+UnityPluginForWindowsPhone.Class1.GetDeviceName);

		UnityPluginForWindowsPhone.Class1.ugasniReklamo ();


	}
	
	// Update is called once per frame
	void Update () {
	
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
