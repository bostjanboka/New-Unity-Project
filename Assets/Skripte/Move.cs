using UnityEngine;
using System.Collections;
//using UnityPluginForWindowsPhone;
using GoogleMobileAds.Api;




//using PlugInWP;



public class Move : MonoBehaviour {

	// Use this for initialization
	public bool prikaziReklamoBool=false;
	public bool ugasniReklamoBool=false;

	public bool loadCelo=false;
	public bool showCelo=false;
	static BannerView bannerView;
	static InterstitialAd interstitial;
	static AdRequest request;


	void Start () {

		interstitial = new InterstitialAd("ca-app-pub-6604259944075538/5290666006");



		request = new AdRequest.Builder().Build();
		UnityPluginForWindowsPhone.Class1.konstruktor ("ca-app-pub-6604259944075538/1359994004", false);	


	}

	public static void ugasniReklamo(){
		//UnityPluginForWindowsPhone.Class1.ugasniReklamo ();
		//bannerView.Hide();

	}

	public static void prizgiReklamo(){
		//UnityPluginForWindowsPhone.Class1.prizgiReklamo ();
		//bannerView.Show();
	}

	public static void loadCelozaslonsko(){
		UnityPluginForWindowsPhone.Class1.loadCelozaslonsko ();
		interstitial.LoadAd(request);

	}

	public static void showCelozaslonsko(){
		UnityPluginForWindowsPhone.Class1.showCelozaslonsko ();
		if (interstitial.IsLoaded()) {
			interstitial.Show();
		}

	}

	public static void showRate(){
		UnityPluginForWindowsPhone.Class1.prizgiRate ();
		Application.OpenURL ("market://details?id=com.mordenkul.mordenElf");
	
	}

	
	// Update is called once per frame
	void Update () {
		if (prikaziReklamoBool) {
			prikaziReklamoBool=false;
			//prizgiReklamo();
		}

		if (ugasniReklamoBool) {
			ugasniReklamoBool=false;
			//ugasniReklamo();
		}

		if (loadCelo) {
			loadCelo=false;
			//loadCelozaslonsko();
		}

		if (showCelo) {
			showCelo=false;
			//showCelozaslonsko();
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
