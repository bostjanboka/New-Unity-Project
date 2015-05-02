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
using UnityEngine.UI;

public class userService : MonoBehaviour {

	// Use this for initialization
	public string apiKey  ="7d5819403473acccbf1a5dbe6a9362e32e24742f3170e4d3a6a2cca072f38abf";						// API key that you have receieved after the success of app creation from AppHQ
	public string secretKey ="2b45ce60091b3d57733551d6b0363ca0bb6cdf2ea002f59852990da09d650268";					// SECRET key that you have receieved after the success of app creation from AppHQ
	public string gameName ="mordenelf";
	public string userName;
	public static IList<Game.Score> scoreList;
	public static bool scoreLista=false;

	public InputField app42InputNick;
	public InputField app42InputEmail;
	public Text playerName;

	void Awake(){
		//PlayerPrefs.DeleteAll ();
		DontDestroyOnLoad (gameObject);
	}

	ServiceAPI sp = null;
	ScoreBoardService scoreBoardService = null; // Initializing ScoreBoard Service.
	StorageService storageService = null;
	UserService userSer = null;

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
			playerName.text=PlayerX;
			PlayerX=null;

		}
	}

	public void saveScore(String name){

		Debug.Log (name);
		App42Log.SetDebug (true);
		scoreBoardService = sp.BuildScoreBoardService (); // Initializing ScoreBoard Service.

		scoreBoardService.SaveUserScore (gameName, name , userScore+100, new UnityCallBack());


	}

	public void narediUser1(){
		String scoreId = LeveliManeger._instance.getIdPlayer ();
		String userId = LeveliManeger._instance.getIdUser ();
		if (userId != null) {
			getUser ();
		} else {
			if (scoreId != null) {
				StorageService storageService = App42API.BuildStorageService ();  
				storageService.FindDocumentById ("mordenelf", "user", scoreId, new UnityUserCallBack ()); 
			} else {
				StorageService storageService = App42API.BuildStorageService ();   
				storageService.FindAllDocumentsCount ("mordenelf", "user", new UnitySteviloUserCallBack ());
			}
		}

		   
	}

	public void getTopNRankings(){
		scoreLista = false;
		scoreBoardService = sp.BuildScoreBoardService (); // Initializing ScoreBoard Service.
		scoreBoardService.GetTopNRankers ("mordenelf", 10, new UnityCallBack());
	}

	public void signUpUser(){


		userSer = sp.BuildUserService (); // Initializing UserService.
		userSer.CreateUser (app42InputNick.text, "password", app42InputEmail.text, new UserResponse());

	}

	public void narediUser(int stevilo){

		String json = "{\"name\":\"Player"+stevilo+"\"}";  
		App42Log.SetDebug (true);
		storageService = sp.BuildStorageService (); // Initializing Storage Service.
		storageService.InsertJSONDocument ("mordenelf", "user",json , new UnityUserCallBack()); 

	}

	public void getUser(){
		userSer = sp.BuildUserService (); // Initializing UserService.
		userSer.GetUser (LeveliManeger._instance.getIdUser(), new UserResponse());
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
					LeveliManeger._instance.setIdUser(userObj.GetUserName());
					PlayerX=userObj.GetUserName();
					if (profileObj != null )
					{
						Debug.Log ("FIRST NAME" + profileObj.GetFirstName());
						Debug.Log ("SEX" + profileObj.GetSex());
						Debug.Log ("LAST NAME" + profileObj.GetLastName());
					}
				}
				else
				{
					IList<User> userList = (IList<User>)user;
					result = userList[0].ToString();
					Debug.Log ("UserName : " + userList[0].GetUserName());
					Debug.Log ("EmailId : " + userList[0].GetEmail());
					
				}
			}
			catch (App42Exception e)
			{
				result = e.ToString();
				Debug.Log ("App42Exception : "+ e);
			}
		}
		
		public void OnException(Exception e)
		{
			result = e.ToString();
			Debug.Log ("Exception : " + e);
		}
		
		public string getResult() {
			return result;
		}	
	}

	public class UnityCallBack : App42CallBack  
	{  
		private string result = "";
		
		public void OnSuccess (object obj)
		{
			if (obj is Game) {
				Game gameObj = (Game)obj;
				result = gameObj.ToString ();
				Debug.Log ("GameName : " + gameObj.GetName ());
				if (gameObj.GetScoreList () != null) {
					scoreList = gameObj.GetScoreList ();
					scoreLista=true;
					for (int i = 0; i < scoreList.Count; i++) {
						Debug.Log ("UserName is  : " + scoreList [i].GetUserName ());
						Debug.Log ("CreatedOn is  : " + scoreList [i].GetCreatedOn ());
						Debug.Log ("ScoreId is  : " + scoreList [i].GetScoreId ());
						Debug.Log ("Value is  : " + scoreList [i].GetValue ());
					}
				}
			} else {
				IList<Game> game = (IList<Game>)obj;
				result = game.ToString ();
				for (int j = 0; j < game.Count; j++) {
					Debug.Log ("GameName is   : " + game [j].GetName ());
					Debug.Log ("Description is  : " + game [j].GetDesription ());
				}
			}
			
		}
		
		public void OnException (Exception e)
		{
			result = e.ToString ();
			Debug.Log ("EXCEPTION : " + e);
			
		}
		
		public string getResult ()
		{
			return result;
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
				LeveliManeger._instance.setIdPlayer(jsonDocList[i].GetDocId());
				PlayerX = jsonDocList[i].GetJsonDoc();
				String ime = PlayerX.Split(':')[1];
				ime = ime.Replace ("}", "");
				ime = ime.Replace ('"', ' ');
				PlayerX=ime;
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
