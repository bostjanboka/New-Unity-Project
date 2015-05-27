using UnityEngine;
using System.Collections;
using Prime31;

public class OglasiSkripta :  MonoBehaviourGUI {

	private string _appId = "8bec5eba192740a9b6c28d400e492d50"; // Replace with the appId from the InMobi web portal!


	bool loadAd = false;

	public void initReklamo(){
		InMobiAndroid.init( _appId);
		DontDestroyOnLoad(gameObject);
	}

	public void loadReklamo(){
		InMobiAndroid.loadInterstitial( _appId );
		loadAd = false;
	}

	public void showReklamo(){
		if((string.Compare(InMobiAndroid.getInterstitialState(), "Ready") == 0 || string.Compare(InMobiAndroid.getInterstitialState(),"READY") == 0)&& !loadAd){
			loadAd = true;
			InMobiAndroid.showInterstitial();
		}

	}
	
}
