using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class InMobiAndroidEventListener : MonoBehaviour
{
#if UNITY_ANDROID

	void OnEnable()
	{
		// Listen to all events for illustration purposes
		InMobiAndroidManager.onDismissInterstitialScreenEvent += onDismissInterstitialScreenEvent;
		InMobiAndroidManager.onInterstitialFailedEvent += onInterstitialFailedEvent;
		InMobiAndroidManager.onInterstitialInteractionEvent += onInterstitialInteractionEvent;
		InMobiAndroidManager.onInterstitialLoadedEvent += onInterstitialLoadedEvent;
		InMobiAndroidManager.onLeaveApplicationEvent += onLeaveApplicationEvent;
		InMobiAndroidManager.onShowInterstitialScreenEvent += onShowInterstitialScreenEvent;
		InMobiAndroidManager.onBannerInteractionEvent += onBannerInteractionEvent;
		InMobiAndroidManager.onBannerRequestFailedEvent += onBannerRequestFailedEvent;
		InMobiAndroidManager.onBannerRequestSucceededEvent += onBannerRequestSucceededEvent;
		InMobiAndroidManager.onDismissBannerScreenEvent += onDismissBannerScreenEvent;
		InMobiAndroidManager.onShowBannerScreenEvent += onShowBannerScreenEvent;
		InMobiAndroidManager.onIncentCompletedEvent += onIncentCompletedEvent;

	}


	void OnDisable()
	{
		// Remove all event handlers
		InMobiAndroidManager.onDismissInterstitialScreenEvent -= onDismissInterstitialScreenEvent;
		InMobiAndroidManager.onInterstitialFailedEvent -= onInterstitialFailedEvent;
		InMobiAndroidManager.onInterstitialInteractionEvent -= onInterstitialInteractionEvent;
		InMobiAndroidManager.onInterstitialLoadedEvent -= onInterstitialLoadedEvent;
		InMobiAndroidManager.onLeaveApplicationEvent -= onLeaveApplicationEvent;
		InMobiAndroidManager.onShowInterstitialScreenEvent -= onShowInterstitialScreenEvent;
		InMobiAndroidManager.onBannerInteractionEvent -= onBannerInteractionEvent;
		InMobiAndroidManager.onBannerRequestFailedEvent -= onBannerRequestFailedEvent;
		InMobiAndroidManager.onBannerRequestSucceededEvent -= onBannerRequestSucceededEvent;
		InMobiAndroidManager.onDismissBannerScreenEvent -= onDismissBannerScreenEvent;
		InMobiAndroidManager.onShowBannerScreenEvent -= onShowBannerScreenEvent;
		InMobiAndroidManager.onIncentCompletedEvent -= onIncentCompletedEvent;
	}



	void onDismissInterstitialScreenEvent()
	{
		Debug.Log( "onDismissInterstitialScreenEvent" );
	}


	void onInterstitialFailedEvent( IMErrorCode error )
	{
		Debug.Log( "onInterstitialFailedEvent: " + error );
	}


	void onInterstitialInteractionEvent( Dictionary<string,object> data )
	{
		Debug.Log( "onInterstitialInteractionEvent" );
		Prime31.Utils.logObject( data );
	}


	void onInterstitialLoadedEvent()
	{
		Debug.Log( "onInterstitialLoadedEvent" );
	}


	void onLeaveApplicationEvent()
	{
		Debug.Log( "onLeaveApplicationEvent" );
	}


	void onShowInterstitialScreenEvent()
	{
		Debug.Log( "onShowInterstitialScreenEvent" );
	}

	void  onIncentCompletedEvent( Dictionary<string,object> data)
	{
		Debug.Log( "onIncentCompletedEvent" );
		Prime31.Utils.logObject( data );
	}


	void onBannerInteractionEvent( Dictionary<string,object> data )
	{
		Debug.Log( "onBannerInteractionEvent" );
		Prime31.Utils.logObject( data );
	}


	void onBannerRequestFailedEvent( IMErrorCode error )
	{
		Debug.Log( "onBannerRequestFailedEvent: " + error );
	}


	void onBannerRequestSucceededEvent()
	{
		Debug.Log( "onBannerRequestSucceededEvent" );
	}


	void onDismissBannerScreenEvent()
	{
		Debug.Log( "onDismissBannerScreenEvent" );
	}


	void onShowBannerScreenEvent()
	{
		Debug.Log( "onShowBannerScreenEvent" );
	}
	
#endif
}


