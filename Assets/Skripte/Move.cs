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
		//gameObject.AddComponent (PlugInWP.Class2);
		//Debug.Log(""+UnityPluginForWindowsPhone.Class1.GetDeviceName);
		//UnityPluginForWindowsPhone.Class1.konstruktor ();
		//interstitial.Destroy ();
		//interstitial = new InterstitialAd("ca-app-pub-6223160944701050/1650693929");

		//PlayerPrefs.DeleteAll ();
		//PlayerPrefs.Save ();
		//bannerView.Destroy ();
		//bannerView = new BannerView(
		//	"ca-app-pub-6223160944701050/8340773121", AdSize.SmartBanner, AdPosition.Top);

		//request = new AdRequest.Builder().Build();
		//bannerView.LoadAd(request);
		//bannerView.Show();
		// ugasniReklamo();		


	}

	public static void ugasniReklamo(){
		UnityPluginForWindowsPhone.Class1.ugasniReklamo ();
		//bannerView.Hide();

	}

	public static void prizgiReklamo(){
		UnityPluginForWindowsPhone.Class1.prizgiReklamo ();
		//bannerView.Show();
	}

	public static void loadCelozaslonsko(){
		UnityPluginForWindowsPhone.Class1.loadCelozaslonsko ();
		//interstitial.LoadAd(request);
	}

	public static void showCelozaslonsko(){
		UnityPluginForWindowsPhone.Class1.showCelozaslonsko ();
		//if (interstitial.IsLoaded()) {
		//	interstitial.Show();
		//}
	}

	public static void showRate(){
		UnityPluginForWindowsPhone.Class1.prizgiRate ();
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
