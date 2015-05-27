using UnityEngine;
using System.Collections.Generic;
using Prime31;


public class InMobiUI : MonoBehaviourGUI
{
#if UNITY_ANDROID
	private string _appId = "57333bc607224b919d75aedce28350f8"; // Replace with the appId from the InMobi web portal!



	void OnGUI()
	{
		beginColumn();

		if( GUILayout.Button( "Initialize" ) )
		{
			var dict = new Dictionary<string,string>();
			dict.Add( "age", "20" );
			dict.Add( "gender", "GENDER_MALE" );
			dict.Add( "education", "EDUCATION_HIGHSCHOOLORLESS" );
			dict.Add( "ethnicity", "ETHNICITY_ASIAN" );
			dict.Add( "dob", "1984-11-12" );
			dict.Add( "income", "200" );
			dict.Add( "maritalStatus", "MARITAL_STATUS_SINGLE" );
			dict.Add( "hasChildren", "TRUE" );
			dict.Add( "sexualOrientation", "SEXUAL_ORIENTATION_STRAIGHT" );
			dict.Add( "language", "eng" );
			dict.Add( "postalCode", "11111" );
			dict.Add( "areaCode", "435" );
			dict.Add( "deviceIdMasks", "EXCLUDE_ODIN1");
			dict.Add( "interests", "swimming, adventure sports" );
			InMobiAndroid.init( _appId,dict);
		}
	
		
		if( GUILayout.Button( "Start Session" ) )
		{
			InMobiAndroid.startSessionManually();
		}


		if( GUILayout.Button( "Set Log Level to Debug" ) )
		{
			InMobiAndroid.setLogLevel( InMobiLogLevel.Debug );
		}


		if( GUILayout.Button( "End Session" ) )
		{
			InMobiAndroid.endSessionManually();
		}


		if( GUILayout.Button( "Track Custom Event" ) )
		{
			InMobiAndroid.tagEvent( "my-custom-event" );
		}


		if( GUILayout.Button( "Track Custom Event with Params" ) )
		{
			var dict = new Dictionary<string,string>();
			dict.Add( "custom-key", "custom-value" );
			dict.Add( "level", "one" );
			InMobiAndroid.tagEvent( "my-other-custom-event", dict );
		}


		if( GUILayout.Button( "Create Banner (320x50)" ) )
		{
			InMobiAndroid.createBanner( InMobiAdPosition.BottomCenter, _appId, InMobiAdSize.Unit_320x50, 20 );
		}


		if( GUILayout.Button( "Create Banner (728x90)" ) )
		{
			InMobiAndroid.createBanner( InMobiAdPosition.BottomRight, _appId, InMobiAdSize.Unit_728x90, 20 );
		}


		if( GUILayout.Button( "Destroy Banner" ) )
		{
			InMobiAndroid.destroyBanner();
		}


		endColumn( true );


		if( GUILayout.Button( "Load Interstitial" ) )
		{
			InMobiAndroid.loadInterstitial( "57333bc607224b919d75aedce28350f8" );
		}


		if( GUILayout.Button( "Get Interstitial State" ) )
		{
			Debug.Log( "interstitial state: " + InMobiAndroid.getInterstitialState() );
		}


		if( GUILayout.Button( "Show Interstitial" ) )
		{
			InMobiAndroid.showInterstitial();
		}


		if( GUILayout.Button( "Begin Section" ) )
		{
			InMobiAndroid.beginSection( "Some_Section" );
		}


		if( GUILayout.Button( "End Section" ) )
		{
			InMobiAndroid.endSection( "Some_Section" );
		}

		if( GUILayout.Button( "set user attrbute" ) )
		{

			InMobiAndroid.setUserAttribute("test","test");
		}

		if( GUILayout.Button( "custom goal" ) )
		{
			
			InMobiAndroid.reportCustomGoal("test");
		}


		endColumn( false );
	}
#endif
}
