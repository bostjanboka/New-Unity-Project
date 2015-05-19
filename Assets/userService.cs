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
	public static string playerName=null;
	public static string userRank="NA";
	public static string[] scori=null;

	public static string playerX = null;

	public static bool posodobiScore=false;

	ServiceAPI sp = null;
	ScoreBoardService scoreBoardService = null; // Initializing ScoreBoard Service.
	UserService userSer = null;

	UserRank userRankCall = new UserRank();
	TopNRank topNRankCall = new TopNRank();
	CreateUser createUserCall = new CreateUser();
	SaveScore saveScoreCall = new SaveScore();


	void Awake(){
		//PlayerPrefs.DeleteAll ();
		DontDestroyOnLoad (gameObject);
	}



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
		if (LeveliManeger._instance.getIdUser () != null) {
			playerName = LeveliManeger._instance.getIdUser ();
			getUserRank();
		}

	}
	
	// Update is called once per frame
	void Update () {
		if(userRankCall.getResult () != null){
			userRank = userRankCall.getResult ();
		}

		if (topNRankCall.getResult() != null) {
			scori=topNRankCall.getResult();
		}

		if (createUserCall.getResult () != null) {
			if(createUserCall.getResult ().Equals("12success12")){
				playerName = playerX;
				LeveliManeger._instance.setIdUser(playerX);
				Meni_Gumbi.pojdiVMeni=true;
			}else{
				Meni_Gumbi.errorText = createUserCall.getResult ();
			}
		}

		if (posodobiScore) {

			posodobiScore=false;
			saveScore();
		}


	}

	public void saveScore(){
		if (playerName != null && LeveliManeger._instance.getIdScore () == null) {
			Debug.Log (name);
			App42Log.SetDebug (true);
			scoreBoardService = sp.BuildScoreBoardService (); // Initializing ScoreBoard Service.
			Debug.Log (LeveliManeger._instance.getSkupniCas () + "skupni cassss");
			scoreBoardService.SaveUserScore (gameName, playerName, Mathf.Floor (LeveliManeger._instance.getSkupniCas () * 10), saveScoreCall);
		} else if (LeveliManeger._instance.getIdScore() != null) {

			scoreBoardService = sp.BuildScoreBoardService ();   
			scoreBoardService.EditScoreValueById(LeveliManeger._instance.getIdScore(), Mathf.Floor (LeveliManeger._instance.getSkupniCas () * 10), saveScoreCall);   
		}


	}




	public void getUserRank(){
		scoreBoardService = sp.BuildScoreBoardService (); // Initializing ScoreBoard Service.
		scoreBoardService.GetUserRanking("mordenelf", playerName, userRankCall);
	}

	public void getTopNRankings(){
		scoreBoardService = sp.BuildScoreBoardService (); // Initializing ScoreBoard Service.
		scoreBoardService.GetTopNRankers ("mordenelf", 100, topNRankCall);
	}


	public void updateUser(string ime){
		userSer = sp.BuildUserService ();  
		userSer.CreateUser (ime, "boka", ime+"@gmail.com", createUserCall); 
	}



	


	public class CreateUser : App42CallBack  
	{  
		private string result = null;
		public void OnSuccess(object response)  
		{  
			result = "12success12";
			User user = (User) response;  

		}  
		public void OnException(Exception e)  
		{  
			result = e.ToString ();

			App42Log.Console("Exception : " + e);  
		}  
		public string getResult() {
			return result;
		}

	}  




	public class UserRank : App42CallBack  
	{  

		private string result = null;

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
				result = game.GetScoreList()[i].GetRank();
			}  
		}  
		
		public void OnException(Exception e)  
		{  
			App42Log.Console("Exception : " + e);  
		}  

		public string getResult ()
		{
			return result;
		}
	}  

	public class TopNRank : App42CallBack  
	{  
		private string[] result; 
		
		public void OnSuccess (object obj)
		{
			if (obj is Game) {
				Game gameObj = (Game)obj;

				Debug.Log ("GameName : " + gameObj.GetName ());
				if (gameObj.GetScoreList () != null) {
					IList<Game.Score> scoreList = gameObj.GetScoreList ();
					result = new string[scoreList.Count];
					for (int i = 0; i < scoreList.Count; i++) {
						Debug.Log ("UserName is  : " + scoreList [i].GetUserName ());

						Debug.Log ("CreatedOn is  : " + scoreList [i].GetCreatedOn ());
						Debug.Log ("ScoreId is  : " + scoreList [i].GetScoreId ());
						Debug.Log ("Value is  : " + scoreList [i].GetValue ());
						result[i] = scoreList [i].GetUserName ()+":"+scoreList [i].GetValue ();
					}
				}
			} else {
				IList<Game> game = (IList<Game>)obj;

				for (int j = 0; j < game.Count; j++) {
					Debug.Log ("GameName is   : " + game [j].GetName ());
					Debug.Log ("Description is  : " + game [j].GetDesription ());
				}
			}
			
		}
		
		public void OnException (Exception e)
		{

			Debug.Log ("EXCEPTION : " + e);
			
		}
		
		public string[] getResult ()
		{
			return result;
		}
	}

	public class SaveScore : App42CallBack  
	{  
		private string result = "";
		
		public void OnSuccess (object obj)
		{
			
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
