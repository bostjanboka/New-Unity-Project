using UnityEngine;
using System.Collections;
using com.shephertz.app42.paas.sdk.csharp.user;
using com.shephertz.app42.paas.sdk.csharp;
using System.Net;
using System;

public class GetUser : ThreadedJob {
	public string apiKey  ="7d5819403473acccbf1a5dbe6a9362e32e24742f3170e4d3a6a2cca072f38abf";						// API key that you have receieved after the success of app creation from AppHQ
	public string secretKey ="2b45ce60091b3d57733551d6b0363ca0bb6cdf2ea002f59852990da09d650268";					// SECRET key that you have receieved after the success of app creation from AppHQ
	public string gameName ="mordenelf";
	// Use this for initialization
	string ime=null;
	static UserService userSer = null;
	public static ServiceAPI sp = null;

	public static string PlayerX=null;
	public static string idUserja;

	#if UNITY_EDITOR
	public static bool Validator (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
	{return true;}
	#endif
	protected override void ThreadFunction()
	{
		Debug.Log("Noter v playerX");
		// Do your threaded task. DON'T use the Unity API here
		#if UNITY_EDITOR
		Debug.Log("Noter v player22");
		ServicePointManager.ServerCertificateValidationCallback = Validator;
		#endif
		Debug.Log("Noter v player23");
		sp = new ServiceAPI (apiKey,secretKey);
		Debug.Log("Noter v player2");
		userSer = sp.BuildUserService (); // Initializing UserService.
		Debug.Log("Noter v playerX3");
		if (idUserja != null) {

			userSer.GetUser (idUserja, new UserResponse ());
			Debug.Log("Noter v playerX4");
		} else {
			PlayerX = "NO Con";
		}
		while (PlayerX == null) {
			Debug.Log("Noter v playerX1");
		}

	}

	public override string OnFinished()
	{
		return PlayerX;
	}

	public class UserResponse : App42CallBack
	{
		private string result = "";
		public void OnSuccess(object user)
		{
			try
			{
				if (user is User)
				{
					User userObj = (User)user;
					result = userObj.ToString();
					Debug.Log ("UserName : " + userObj.GetUserName());
					Debug.Log ("EmailId : " + userObj.GetEmail());
					User.Profile profileObj = (User.Profile)userObj.GetProfile();

					PlayerX=userObj.GetUserName();
					
				}
				//Meni_Gumbi.pojdiVMeni=true;
			}
			catch (App42Exception e)
			{
				Meni_Gumbi.errorText = e.ToString();
				result = e.ToString();
				Debug.Log ("App42Exception : "+ e);
			}
		}
		
		public void OnException(Exception e)
		{
			Meni_Gumbi.errorText = e.ToString();
			result = e.ToString();
			Debug.Log ("Exception : " + e);
		}
		
		public string getResult() {
			return result;
		}	
	}
}


