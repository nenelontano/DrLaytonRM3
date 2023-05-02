using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
//using Newtonsoft.Json;    inutile se non importi json dal sito di unity come fa vedere nel video 5
using UnityEngine.UI;


public class PlayfabManager : MonoBehaviour {

    //VARIABILI
    public static PlayfabManager instance;    //non funziona 
    [Header("UI")]
    public Text messageText;
    public InputField emailInput;
    public InputField passwordInput;



    //LOGIN INIZIALE
    // Start is called before the first frame update
    void Start() {
        Login();
    }
   
    void Login() {
        
        var request = new LoginWithCustomIDRequest {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
    }

    void OnLoginSuccess(LoginResult result) {
        //messageText.text = "Logged in;     non la usiamo perche abbiamo salato il video dove fa comparire i messaggi
        Debug.Log("Logged in");
        Debug.Log("Successful login/account create");
    }







    //CLASSIFICA
    public void SendLeaderboard(int score){
        var request= new UpdatePlayerStatisticsRequest{
            Statistics= new List<StatisticUpdate>{
                new StatisticUpdate{
                    StatisticName="Score",
                    Value=score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request,OnLeaderBoardUpdate,OnError);
    }

    void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result){
        Debug.Log("Successfull leaderboard sent");
    }

    public void GetLeaderboard() {

        var request = new GetLeaderboardRequest {
            StatisticName = "experienceScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderBoardGet, OnError);
    }


    void OnLeaderBoardGet(GetLeaderboardResult result) {
    
        foreach (var item in result.Leaderboard) {
            Debug.Log(item.Position + "" + item.PlayFabId + "" + item.StatValue);
        }
    }





    //OPERAZIONI DI SIGN IN
    public void RegisterButton() {
        if(passwordInput.text.Length < 6) {
            Debug.Log("Password troppo corta");
            //messageText.text = "Password troppo corta";               //inutile perche abbiamo saltato la parte delle condizioni sulla password
            return;
        }                 

        var request = new RegisterPlayFabUserRequest {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result) {
        Debug.Log("Registered and logged in");
        //messageText.text = "Registered and logged in";
    }

    public void LoginButton() {
        var request = new LoginWithEmailAddressRequest {
            Email = emailInput.text,
            Password = passwordInput.text,
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    public void ResetPasswordButton() {
        var request = new SendAccountRecoveryEmailRequest {
            Email = emailInput.text,
            TitleId = "2087F"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }
    void OnPasswordReset(SendAccountRecoveryEmailResult result) {
        Debug.Log("Password reset mail sent");
    }






    //FUNZIONI USATE
   // Update is called once per frame
    void OnError(PlayFabError error)  {
        //messageText.text = error.ErrorMessage;     non la usiamo perche abbiamo salato il video dove fa comparire i messaggi
        Debug.Log("Error while logging in/creating account");
        Debug.Log(error.GenerateErrorReport());
    }

  
}
