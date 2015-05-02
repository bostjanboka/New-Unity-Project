using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.game;
using AssemblyCSharp;
using System;
using com.shephertz.app42.paas.sdk.csharp.user;
using com.shephertz.app42.paas.sdk.csharp.storage;
using SimpleJSON;

public class userService : MonoBehaviour {

	// Use this for initialization
	public string apiKey  ="7d5819403473acccbf1a5dbe6a9362e32e24742f3170e4d3a6a2cca072f38abf";						// API key that you have receieved after the success of app creation from AppHQ
	public string secretKey ="2b45ce60091b3d57733551d6b0363ca0bb6cdf2ea002f59852990da09d650268";					// SECRET key that you have receieved after the success of app creation from AppHQ
	public string gameName ="mordenelf";
	public string userName;

	void Awake(){
		//PlayerPrefs.DeleteAll ();
		DontDestroyOnLoad (gameObject);
	}

	ServiceAPI sp = null;
	ScoreBoardService scoreBoardService = null; // Initializing ScoreBoard Service.
	StorageService storageService = null;

	public double userScore = 1000;
	public double Score1 = 2000;
	public int max = 2;
	public int offSet = 1;
	public string success;

	static bool uspesnoStevilo=false;
	static int steviloUser;
	static string PlayerX=null;

	
	#if UNITY_EDITOR
	public static bool Validator (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
	{return true;}
	#endif
	void Start ()
	{
		#if UNITY_EDITOR
		ServicePointManager.ServerCertificateValidationCallback = Validator;
		#endif
		sp = new ServiceAPI (apiKey,secretKey);
		//saveScore ();
		narediUser1();
	}
	
	// Update is called once per frame
	void Update () {
		if (uspesnoStevilo) {
			narediUser(steviloUser);
			uspesnoStevilo=false;
		}

		if (PlayerX != null) {
			saveScore(PlayerX);
			PlayerX=null;
		}
	}

	public void saveScore(String name){
		String ime = name.Split(':')[1];
		ime = ime.Replace ("}", "");
		ime = ime.Replace ('"', 'p');
		Debug.Log (ime);
		App42Log.SetDebug (true);
		scoreBoardService = sp.BuildScoreBoardService (); // Initializing ScoreBoard Service.

		scoreBoardService.SaveUserScore (gameName, ime , userScore+100, new UnityCallBack());


	}

	public void narediUser1(){
		String scoreId = LeveliManeger._instance.getIdScore ();
		if (scoreId != null) {
			StorageService storageService = App42API.BuildStorageService();  
			storageService.FindDocumentById("mordenelf", "user",scoreId, new UnityUserCallBack()); 
		} else {
			StorageService storageService = App42API.BuildStorageService();   
			storageService.FindAllDocumentsCount("mordenelf", "user", new UnitySteviloUserCallBack());
		}

		   
	}

	public void narediUser(int stevilo){

		String json = "{\"name\":\"Player"+stevilo+"\"}";  
		App42Log.SetDebug (true);
		storageService = sp.BuildStorageService (); // Initializing Storage Service.
		storageService.InsertJSONDocument ("mordenelf", "user",json , new UnityUserCallBack()); 

	}

	public class UnityCallBack : App42CallBack  
	{  
		public void OnSuccess(object response)  
		{  
			Game game = (Game) response;       
			App42Log.Console("gameName is " + game.GetName());   
			for(int i = 0;i<game.GetScoreList().Count;i++)  
			{  
				App42Log.Console("userName is : " + game.GetScoreList()[i].GetUserName());  
				App42Log.Console("score is : " + game.GetScoreList()[i].GetValue());  
				App42Log.Console("scoreId is : " + game.GetScoreList()[i].GetScoreId());
				App42Log.Console("rank is : " + game.GetScoreList()[i].GetRank());  

			}  
		}  
		
		public void OnException(Exception e)  
		{  
			App42Log.Console("Exception : " + e);  
		}  
	}

	public class UnityUserCallBack : App42CallBack  
	{  
		public void OnSuccess(object response)  
		{  
			Storage storage = (Storage) response;  
			IList<Storage.JSONDocument> jsonDocList = storage.GetJsonDocList();   
			for(int i=0;i <jsonDocList.Count;i++)  
			{     
				App42Log.Console("objectId is " + jsonDocList[i].GetDocId());  
				App42Log.Console("besedilo is " + jsonDocList[i].GetJsonDoc());  
				LeveliManeger._instance.setIdScore(jsonDocList[i].GetDocId());
				PlayerX = jsonDocList[i].GetJsonDoc();
			}    
		}  
		
		public void OnException(Exception e)  
		{  
			App42Log.Console("Exception : " + e);  
		}  
	}  

	public class UnitySteviloUserCallBack : App42CallBack  
	{  
		public void OnSuccess(object response)  
		{  
			App42Response success = (App42Response) response;      
			App42Log.Console("TotalRecords : " + success.GetTotalRecords());  
			steviloUser = success.GetTotalRecords ();
			uspesnoStevilo = true;
		}  
		
		public void OnException(Exception e)  
		{  
			App42Log.Console("Exception : " + e);  
		}  
	}  
}
