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
using com.shephertz.app42.paas.sdk.csharp;

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
	public static String playerName;
	public static String rankUserja;
	public static string firstName;

	void Awake(){
		//PlayerPrefs.DeleteAll ();
		DontDestroyOnLoad (gameObject);
	}

	ServiceAPI sp = null;
	ScoreBoardService scoreBoardService = null; // Initializing ScoreBoard Service.

	static UserService userSer = null;
	static bool flag  = true; 
	public double userScore = 1000;
	public double Score1 = 2000;
	public int max = 2;
	public int offSet = 1;
	public string success;
	public static bool posodobiScore=false;
	public static bool dobiNRanke=false;


	static bool uspesnoStevilo=false;
	static int steviloUser;
	static string PlayerX=null;
	bool userUstvarjen=false;
	static bool shranjenScore=false;


	
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
		dobiUserja();
	}
	
	// Update is called once per frame
	void Update () {
		if (uspesnoStevilo) {
			LeveliManeger._instance.setIdUser("Player"+steviloUser);
			updateUser(null);
			uspesnoStevilo=false;
		}

		if (PlayerX != null) {

			playerName=PlayerX;
			saveScore();
			PlayerX=null;
			userUstvarjen=true;

		}

		if (userUstvarjen) {
			userUstvarjen=false;
			getUserRank();
		}

		if (posodobiScore) {
			posodobiScore=false;
			saveScore();
			Debug.Log("SAVE SCORE");
		}

		if (shranjenScore) {
			shranjenScore=false;
			getUserRank();
			Debug.Log("SHRANJEN SCORE");
		}

		if (dobiNRanke) {
			dobiNRanke=false;
			getTopNRankings();
		}
	}

	public void saveScore(){
		if (playerName != null) {
			Debug.Log (name);
			App42Log.SetDebug (true);
			scoreBoardService = sp.BuildScoreBoardService (); // Initializing ScoreBoard Service.
			Debug.Log(LeveliManeger._instance.getSkupniCas ()+"skupni cassss");
			scoreBoardService.SaveUserScore (gameName, playerName, Mathf.Floor(LeveliManeger._instance.getSkupniCas ()*100), new UnityCallBack ());
		}


	}




	public void getUserRank(){
		scoreBoardService = sp.BuildScoreBoardService (); // Initializing ScoreBoard Service.
		scoreBoardService.GetUserRanking("mordenelf", playerName, new UnityUserRankCallBack());
	}

	public void getTopNRankings(){
		scoreLista = false;
		scoreBoardService = sp.BuildScoreBoardService (); // Initializing ScoreBoard Service.
		scoreBoardService.GetTopNRankers ("mordenelf", 100, new UnityTopNRankBack());
	}

	public void dobiUserja(){
		string user = LeveliManeger._instance.getIdUser ();
		if (user != null) {
			getUser (null);
		} else {
			getUserCount();
		}
	}


	public void updateUser(string ime){
		firstName = ime;
		userSer = App42API.BuildUserService ();  
		userSer.CreateUser (LeveliManeger._instance.getIdUser(), "boka", LeveliManeger._instance.getIdUser()+"@gmail.com", new UnityUpdateUser ()); 
	}

	public void getUser(string ime){
		flag = false;
		if (ime != null) {
			flag=true;
		}
		firstName = ime;
		userSer = sp.BuildUserService (); // Initializing UserService.
		userSer.GetUser (LeveliManeger._instance.getIdUser(), new UserResponse());
	}

	public void getUserCount(){
		userSer = App42API.BuildUserService();  
		userSer.GetAllUsersCount(new UnityUsersCount());   
	}

	public class UnityUsersCount : App42CallBack  
	{  
		public void OnSuccess(object response)  
		{  
			App42Response app42response = (App42Response) response;   
			App42Log.Console("TotalRecords is : " + app42response.GetTotalRecords());  
			uspesnoStevilo = true;
			steviloUser = app42response.GetTotalRecords ();
		}  
		public void OnException(Exception e)  
		{  
			App42Log.Console("Exception : " + e);  
		}  
	}  

	public class UnityUpdateUser : App42CallBack  
	{  
		public void OnSuccess(object response)  
		{  
			if(flag)  
			{  
				User user = (User) response;   
				User.Profile profile = new User.Profile(user);  
				if(firstName != null){
					profile.SetFirstName(firstName);   
				}else{
					profile.SetFirstName(LeveliManeger._instance.getIdUser());
				}

				flag = false;  
				userSer.CreateOrUpdateProfile(user, new UserResponse());  

				/* Above line will create user profile and returns User object which has profile object in it. */  
			}  
			else {  
				User user = (User) response;  
				/* This will create user in App42 cloud and will return User object */    
				App42Log.Console("userName is " + user.GetUserName());  
				App42Log.Console("emailId is " + user.GetEmail());   
			}  
		}  
		public void OnException(Exception e)  
		{  
			Meni_Gumbi.errorText = e.ToString();
			App42Log.Console("Exception : " + e);  
		}  
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

					if (profileObj != null )
					{
						Debug.Log ("FIRST NAME" + profileObj.GetFirstName());
						PlayerX=profileObj.GetFirstName();
					}
					if(flag){
						User user2 = (User) user;   
						User.Profile profile = new User.Profile(user2); 
						if(firstName != null){
							profile.SetFirstName(firstName);   
						}else{
							profile.SetFirstName(LeveliManeger._instance.getIdUser());
						}
						userSer.CreateOrUpdateProfile(user2, new UserResponse());  
						flag=false;
					}
				}
				else
				{
					IList<User> userList = (IList<User>)user;
					result = userList[0].ToString();
					Debug.Log ("UserName : " + userList[0].GetUserName());
					Debug.Log ("EmailId : " + userList[0].GetEmail());
					
				}
				Meni_Gumbi.pojdiVMeni=true;
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


	public class UnityUserRankCallBack : App42CallBack  
	{  
		public void OnSuccess(object response)  
		{  
			Game game = (Game) response;       
			App42Log.Console("gameName is " + game.GetName());   
			for(int i = 0;i<game.GetScoreList().Count;i++)  
			{  
				App42Log.Console("userName is : " + game.GetScoreList()[i].GetUserName());  
				App42Log.Console("rank is : " + game.GetScoreList()[i].GetRank());  
				App42Log.Console("score is : " + game.GetScoreList()[i].GetValue());  
				App42Log.Console("scoreId is : " + game.GetScoreList()[i].GetScoreId());  
				rankUserja = game.GetScoreList()[i].GetRank();
			}  
		}  
		
		public void OnException(Exception e)  
		{  
			App42Log.Console("Exception : " + e);  
		}  
	}  

	public class UnityTopNRankBack : App42CallBack  
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
					shranjenScore=true;
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

}
